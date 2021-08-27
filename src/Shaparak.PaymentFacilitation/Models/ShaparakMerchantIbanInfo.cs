using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Models {

    /// <summary>
    /// هر شماره شبا در شبکه پرداخت کارت می تواند به یک و فقط یک متقاضی تعلق داشته باشد. با این حال، شبای تعریف شده
    /// برای یک متقاضی، می تواند تحت رابطه شراکت در پذیرندگی متقاضی دیگری جهت تسهیم وجوه مورد استفاده قرار گیرد.
    /// </summary>
    public class ShaparakMerchantIbanInfo {

        /// <summary>
        /// *شماره شبا در این جدول به عنوان کلید تلقی می گردد.
        /// </summary>
        [Required, Description("شماره شبا"), MinLength(26), MaxLength(34)]
        [JsonProperty("merchantIban")]
        public string Iban { get; set; }

        [Required, Description("عنوان شبا")]
        [JsonProperty("Description")]
        public string Description { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
