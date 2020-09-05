using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Leff.FiasPublicApi.Models;
using Leff.FiasPublicApi.Tools;

namespace Leff.FiasPublicApi
{
    public class FiasApiClient
    {
        private const string BaseUrl = "https://fias.nalog.ru/";

        private readonly HttpClient _httpClient;

        public FiasApiClient() : this(new HttpClient())
        {
        }

        public FiasApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<IList<FiasObject>> GetChildObjectsAsync(FiasObjectDetails parentObject,
            FiasObjectLevelId levelId, bool administrativeHierarchy = false,
            CancellationToken cancellationToken = default)
        {
            if (parentObject == null) throw new ArgumentNullException(nameof(parentObject));

            string parentObjectId = parentObject.ObjectId.ToString(CultureInfo.InvariantCulture);
            var hierarchy = new FiasHierarchy().SetObjectIdByLevelId(parentObject.LevelId, parentObjectId);

            return await GetChildObjectsAsync(hierarchy, levelId, administrativeHierarchy, cancellationToken);
        }

        public async Task<IList<FiasObject>> GetChildObjectsAsync(FiasHierarchy hierarchy, FiasObjectLevelId levelId,
            bool administrativeHierarchy = false, CancellationToken cancellationToken = default)
        {
            if (hierarchy == null) throw new ArgumentNullException(nameof(hierarchy));

            string endpoint = levelId.GetChildObjectSearchEndpointName(administrativeHierarchy);
            string query = hierarchy.GetQueryStringByLevelId(levelId);
            string uriString = $"Search/{endpoint}?{query}";
            var uri = new Uri(uriString, UriKind.Relative);

            using (var response = await _httpClient.GetAsync(uri, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadJsonObjectAsync<IList<FiasObject>>();

                return result;
            }
        }

        public async Task<ExtendedSearchResponse> ExtendedSearchAsync<T>(T extendedSearchRequest,
            CancellationToken cancellationToken = default) where T : SearchRequestBase
        {
            if (extendedSearchRequest == null) throw new ArgumentNullException(nameof(extendedSearchRequest));

            var uri = new Uri("ExtendedSearch/PubExtSearch", UriKind.Relative);
            using (var content = new JsonContent(extendedSearchRequest))
            using (var response = await _httpClient.PostAsync(uri, content, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadJsonObjectAsync<ExtendedSearchResponse>();

                return result;
            }
        }
    }
}
