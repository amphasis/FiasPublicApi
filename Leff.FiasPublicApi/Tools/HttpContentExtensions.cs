using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Tools
{
    internal static class HttpContentExtensions
    {
        public static bool IsContentType(this HttpContent httpContent, string expectedMediaType)
        {
            if (httpContent == null) throw new ArgumentNullException(nameof(httpContent));
            string mediaType = httpContent.Headers.ContentType.MediaType;
            bool isValidMediaType = mediaType.Equals(expectedMediaType, StringComparison.OrdinalIgnoreCase);

            return isValidMediaType;
        }

        public static HttpContent EnsureContentType(this HttpContent httpContent, string expectedMediaType)
        {
            if (httpContent == null) throw new ArgumentNullException(nameof(httpContent));
            string mediaType = httpContent.Headers.ContentType.MediaType;
            bool isValidMediaType = mediaType.Equals(expectedMediaType, StringComparison.OrdinalIgnoreCase);
            if (isValidMediaType) return httpContent;

            string message = $"Invalid response media type: {mediaType}. Expected: {expectedMediaType}";
            throw new HttpRequestException(message);
        }

        public static async Task<T> ReadJsonObjectAsync<T>(this HttpContent httpContent)
        {
            string content = await httpContent.EnsureContentType(JsonContent.MediaType).ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }
    }
}