using AutoMapper;
using ElasticSearch.API.Extensions;
using ElasticSearch.AppCore.Mapping;
using ElasticSearch.BLL.Abstract;
using ElasticSearch.BLL.Concrate;
using ElasticSearch.DAL.Repositories.Derived;
using ElasticSearch.DAL.Repositories.Infrastructor;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddElastic(builder.Configuration);

#region MappingConfiguration

builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region IoC

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IECommerceService, ECommerceService>();
builder.Services.AddScoped<IECommerceRepository, ECommerceRepository>();
builder.Services.AddSingleton<IElasticClient, ElasticClient>();



#endregion

var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
