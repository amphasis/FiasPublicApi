using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ExtendedSearchResponse> ExtendedSearchAsync(Guid fiasGuid,
            CancellationToken cancellationToken = default)
        {
            var searchRequest = new SearchRequestBase {Guid = fiasGuid};
            return await ExtendedSearchAsync(searchRequest, cancellationToken);
        }

        public async Task<ExtendedSearchResponse> ExtendedSearchAsync(FiasObjectLevelId levelId, int objectId,
            CancellationToken cancellationToken = default)
        {
            var hierarchy = new FiasHierarchy(levelId, objectId);
            var searchRequest = new MunicipalSearchRequest {Hierarchy = hierarchy};
            return await ExtendedSearchAsync(searchRequest, cancellationToken);
        }

        public async Task<IList<FiasObject>> GetChildObjectsAsync(Guid fiasGuid, FiasObjectLevelId levelId,
            CancellationToken cancellationToken = default)
        {
            var searchResponse = await ExtendedSearchAsync(fiasGuid, cancellationToken);
            var fiasObject = searchResponse.Data.FirstOrDefault();
            
            if (fiasObject == null)
            {
                string message = $"FIAS object {fiasGuid} not found";
                throw new InvalidOperationException(message);
            }

            return await GetChildObjectsAsync(fiasObject, levelId, cancellationToken: cancellationToken);
        }

        public async Task<IList<FiasObject>> GetChildObjectsAsync(FiasObjectDetails parentObject,
            FiasObjectLevelId levelId, bool administrativeHierarchy = false,
            CancellationToken cancellationToken = default)
        {
            if (parentObject == null) throw new ArgumentNullException(nameof(parentObject));

            var hierarchy = new FiasHierarchy(parentObject.LevelId, parentObject.ObjectId);

            return await GetChildObjectsAsync(hierarchy, levelId, administrativeHierarchy, cancellationToken);
        }

        public async Task<IList<FiasObject>> GetChildObjectsAsync(FiasHierarchy hierarchy, FiasObjectLevelId levelId,
            bool administrativeHierarchy = false, CancellationToken cancellationToken = default)
        {
            if (hierarchy == null) throw new ArgumentNullException(nameof(hierarchy));

            string endpoint = levelId.GetChildObjectSearchEndpointName(administrativeHierarchy);
            string query = hierarchy.GetQueryStringByLevelId(levelId, administrativeHierarchy);
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
