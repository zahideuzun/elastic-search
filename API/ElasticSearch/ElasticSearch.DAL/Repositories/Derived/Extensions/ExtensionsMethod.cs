
using ElasticSearch.AppCore.Entities.ECommerceModel;
using Nest;
using System.Collections.Immutable;

namespace ElasticSearch.DAL.Repositories.Derived.Extensions
{
    public static class ExtensionsMethod
    {
        public static void SetDocumentIds(ISearchResponse<ECommerce> searchResponse)
        {
            foreach (var hit in searchResponse.Hits) hit.Source.Id = hit.Id;
        }

        public static ImmutableList<ECommerce> HandleSearchResponse(ISearchResponse<ECommerce> searchResponse)
        {
            if (!searchResponse.IsValid || searchResponse.Documents == null)
                return ImmutableList<ECommerce>.Empty;

            return searchResponse.Documents.ToImmutableList();
        }

    }
}
