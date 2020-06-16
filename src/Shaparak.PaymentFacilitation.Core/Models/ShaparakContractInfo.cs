using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Infrastructure;

namespace Shaparak.PaymentFacilitation.Core.Models {
    
    /// <summary>
    /// هرگونه مستندی که براساس آن تغییری در وضعیت پذیرندگی مشتری رخ دهد
    /// (مانند و نه محدود به قرارداد تعریف شبای عمومی، قرارداد تعریف پذیرندگی، الحاقیه تغییر شبا، خاتمه قرارداد و ....)
    /// در سامانه جامع به عنوان قرارداد محسوب شده و ارائه اطلاعات آن در قالب کلاس زیر به شاپرک الزامی است.
    /// ص55 مستند وب سرویس شاپرک
    /// </summary>
    public class ShaparakContractInfo {

        /// <summary>
        /// تاریخ عقد قرارداد
        /// </summary>
        [Required, Description("تاریخ عقد قرارداد")]
        [JsonProperty("contractDate")]
        public long ContractDate => ContractDateValue.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="ContractDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        public DateTime ContractDateValue { get; set; }

        /// <summary>
        /// تاریخ اتمام قرارداد
        /// </summary>
        [Description("تاریخ اتمام قرارداد")]
        [JsonProperty("expiryDate")]
        public long? ExpiryDate => ExpiryDateValue?.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="ExpiryDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        public DateTime? ExpiryDateValue { get; set; }

        /// <summary>
        /// تاریخ فعال سازی سرویس بر اساس قرارداد
        /// </summary>
        [Required, Description("تاریخ فعال سازی سرویس بر اساس قرارداد")]
        [JsonProperty("serviceStartDate")]
        public long ServiceStartDate => ServiceStartDateValue.ToTimestamp3();
        
        /// <summary>
        /// Backing field for : <see cref="ServiceStartDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        public DateTime ServiceStartDateValue { get; set; }

        /// <summary>
        /// شماره قرارداد
        /// </summary>
        [Required, Description("شماره قرارداد"), MaxLength(50)]
        [JsonProperty("contractNumber")]
        public string ContractNumber { get; set; }

        /// <summary>
        /// مقادیر سایر فیلدهای این مستند نباید در این
        /// فیلد ارسال شوند.همچنین اطلاعات ارسالی در این
        /// فیلد به منزله اطلاع رسانی رسمی به شاپرک نمی باشد
        /// </summary>
        [Description("توضیحات"), MaxLength(255)]
        public string Description { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
