using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shaparak.PaymentFacilitation.Core.Infrastructure {
    
    internal interface IHttpRestClient<in T, TResult> : IDisposable where T : class {
        
        Task<TResult> PostJsonAsync();

        Task<TResult> PostAsync(string url, T data, Dictionary<string, string> headers = null);

    }
}
