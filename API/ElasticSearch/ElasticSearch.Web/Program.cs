using AutoMapper;
using ElasticSearch.AppCore.Mapping;
using ElasticSearch.BLL.Abstract;
using ElasticSearch.BLL.Concrate;
using ElasticSearch.DAL.Repositories.Derived;
using ElasticSearch.DAL.Repositories.Infrastructor;
using ElasticSearch.WEB.Extensions;

using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IECommerceRepository, ECommerceRepository>();
builder.Services.AddScoped<IECommerceService, ECommerceService>();
builder.Services.AddSingleton<IElasticClient, ElasticClient>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
