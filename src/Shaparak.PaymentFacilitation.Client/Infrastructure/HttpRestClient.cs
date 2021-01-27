using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Core.Infrastructure {

    public class HttpRestClient : IHttpRestClient
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpRestClient(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClient = _httpClientFactory.CreateClient();
        }

        private void addHeaders(Dictionary<string, string> headers = null) {
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var item in headers ?? new Dictionary<string, string>())
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
        }

        public async Task<TResult> PostAsync<T, TResult>(
            T data,
            string url,
            Dictionary<string, string> headers = null) {

            addHeaders(headers);
            var result = await _httpClient.PostAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(data),
                    Encoding.UTF8,
                    "application/json")
            );

            if (!result.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"{result.StatusCode} {result.ReasonPhrase}");

            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public async Task<TResult> PostFormAsync<TResult>(
            IEnumerable<KeyValuePair<string, string>> data,
            string url,
            Dictionary<string, string> headers = null) {
            addHeaders(headers);
            var result = await _httpClient.PostAsync(
                url,
                new FormUrlEncodedContent(data));

            if (!result.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"{result.StatusCode} {result.ReasonPhrase}");

            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

    }
}
