using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// فیلدهای فایل تسویه با پذیرندگان
    /// طبق جدول فرمت فایل تسویه
    /// ص6 مستند "الزامات فنی فعالیت پرداخت یاران در شبکه پرداخت الکترونیکی کشور (فایل تسویه"
    /// </summary>
    public class ShaparakSettlementData {

        /// <summary>
        /// کد 15رقمی پذیرنده
        /// </summary>
        [Required, MinLength(15), MaxLength(15)]
        [JsonProperty("acceptorCode")]
        public string AcceptorCode { get; set; }
        
        /// <summary>
        /// کد سوئیچ شرکت ارائه دهنده خدمات پرداخت
        /// </summary>
        [JsonProperty("iin")]
        public int Iin { get; set; }

        /// <summary>
        /// شماره شبای پرداخت یار
        /// </summary>
        [Required, MinLength(26), MaxLength(26)]
        [JsonProperty("paymentFacilitatorIban")]
        public string PaymentFacilitatorIban { get; set; }
        
        /// <summary>
        /// مبلغ تسویه
        /// </summary>
        [JsonProperty("settlementAmount")]
        public long SettlementAmount { get; set; }

        /// <summary>
        /// مبلغ کارمزد
        /// </summary>
        [JsonProperty("wageAmount")]
        public int WageAmount { get; set; }

        /// <summary>
        /// شماره شبای تسویه
        /// </summary>
        [Required, MinLength(26), MaxLength(26)]
        [JsonProperty("settlementIban")]
        public string SettlementIban { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
