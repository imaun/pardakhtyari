using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shaparak.PaymentFacilitation.Core.Models;
using Shaparak.PaymentFacilitation.Core.Infrastructure;

namespace Shaparak.PaymentFacilitation.Core  {

    /// <summary>
    /// کلاینت ارتباط با وب سرویس شاپرک
    /// دو متد کلی شاپرک را در اختیار می گذارد
    /// </summary>
    public class ShaparakClient {

        #region Constants

        private const string _baseUrl = "https://mms.shaparak.ir/merchant";
        private const string H_AUTH_KEY = "Authorization";
        private const string H_CONTENT_TYPE_VALUE = "application/json";
        private const string H_CONTENT_TYPE_KEY = "Content-Type";
        private const string URL_READ_REQUEST = "webService/readRequestCartableWithFilter";
        private const string URL_WRITE_REQUEST = "webService/writeExternalRequest";

        #endregion
        
        #region Properties

        /// <summary>
        /// Shaparak Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Shaparak Password
        /// </summary>
        public string Password { get; set; }

        #endregion

        /// <summary>
        /// Pass <see cref="Username"/> and <see cref="Password"/> in plain text.
        /// This class will convert it to Base64 in order to build Basic Authorization header
        /// for Shaparak WebService.
        /// </summary>
        /// <param name="username">Shaparak Username</param>
        /// <param name="password">Shaparak Password</param>
        public ShaparakClient(string username, string password) {
            Username = username;
            Password = password;
        }

        public async Task<ReadRequestCartableResponse> ReadRequestCartable(ShaparakReadRequest model) {
            if (model == null)
                throw new System.NullReferenceException("The model cannot be null.");

            string url = $"{_baseUrl}/{URL_READ_REQUEST}";
            ReadRequestCartableResponse result;
            using (var client = new HttpRestClient<ShaparakReadRequest, ReadRequestCartableResponse>()) {
                result = await client.PostAsync(url, model, getHeaders());
            }
            return result;
        }

        public async Task<ShaparakWriteResponse> WriteExternalRequest(ShaparakWriteRequest model) {
            if (model == null)
                throw new System.NullReferenceException("The model cannot be null.");

            string url = $"{_baseUrl}/{URL_WRITE_REQUEST}";
            ShaparakWriteResponse result;
            
            using (var client = new HttpRestClient<ShaparakWriteRequest, ShaparakWriteResponse>()) {
                result = await client.PostAsync(url, model, getHeaders());
            }
            return result;
        }

        #region Helper Methods

        private string base64Encode(string what)
            => Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(what));
        
        private string getAuthorizationValue() =>
             $"Basic {base64Encode($"{Username}:{Password}")}";
        
        private Dictionary<string, string> getHeaders() =>
            new Dictionary<string, string>
            {
                { H_AUTH_KEY, getAuthorizationValue() },
                { H_CONTENT_TYPE_KEY, H_CONTENT_TYPE_KEY }
            };

        #endregion

    }
}
