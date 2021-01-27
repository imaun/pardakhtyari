using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shaparak.PaymentFacilitation.Core.Infrastructure {

    public interface IHttpRestClient
    {
        Task<TResult> PostAsync<T, TResult>(
            T data,
            string url,
            Dictionary<string, string> headers = null);

        Task<TResult> PostFormAsync<TResult>(
            IEnumerable<KeyValuePair<string, string>> data,
            string url,
            Dictionary<string, string> headers = null);
    }
}
