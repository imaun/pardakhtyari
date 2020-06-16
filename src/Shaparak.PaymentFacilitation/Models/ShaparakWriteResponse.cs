using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Models {

    /// <summary>
    /// مدل پاسخ متد WriteExternalRequest
    /// وب سرویس جامع
    /// </summary>
    public class ShaparakWriteResponse {

        [Description("شماره پیگیری")]
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [Description("نتیجه موفق یا ناموفق بودن عملیات")]
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// طبق جدول (23-5) مستند شاپرک
        /// </summary>
        [Description("دلایل رد درخواست در سامانه")]
        [JsonProperty("requestRejectionReason")]
        public List<ShaparakErrorObject> RejectionReason { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
