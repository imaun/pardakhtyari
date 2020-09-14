using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Core.Infrastructure {

    internal class HttpRestClient<T, TResult> : IHttpRestClient<T, TResult>, IDisposable where T: class {

        private readonly HttpClient _httpClient;

        public HttpRestClient() {
            _httpClient = new HttpClient();
        }

        public HttpRestClient(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public void Dispose() {
            _httpClient.Dispose();
        }

        public async Task<TResult> PostAsync(
            string url,
            T data,
            Dictionary<string, string> headers = null)
        {
            foreach (var item in headers ?? new Dictionary<string, string>())
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);

            var result = await _httpClient.PostAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(data),
                    Encoding.UTF8,
                    "application/json")
            );

            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"{result.StatusCode} {result.ReasonPhrase}");
            }

            return JsonConvert.DeserializeObject<TResult>(await result.Content.ReadAsStringAsync());
        }

        public Task<TResult> PostJsonAsync() {
            throw new NotImplementedException();
        }
        
    }
}
