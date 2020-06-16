using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// مستند شاپرک
    ///ص 62
    /// </summary>
    public class ShaparakShopAndAcceptor {

        [Required, Description("اطلاعات فروشگاه")]
        [JsonProperty("shop")]
        public ShaparakShop Shop { get; set; }

        /// <summary>
        /// این مورد برای درخواست های ترمینال جدید، تغییر شبا، جمع آوری ترمینال،
        /// تغییر آدرس فروشگاه پذیرندگی، فعال سازی مجدد ترمینال، تکمیل اطلاعات از طرف 
        /// شرکت ارائه دهنده خدمات پرداخت اجباری است
        /// </summary>
        [JsonProperty("acceptors")]
        [Description("اطلاعات پذیرندگی و پایانه های فروشگاه")]
        public List<ShaparakAcceptor> Acceptors { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
