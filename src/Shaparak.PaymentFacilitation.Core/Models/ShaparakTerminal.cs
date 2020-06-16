using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Enums;
using Shaparak.PaymentFacilitation.Core.Infrastructure;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// اقلام اطلاعاتی ترمینال پذیرنده در سیستم شاپرک
    /// </summary>
    public class ShaparakTerminal {

        [Description("شماره یکتای جزئیات درخواست")]
        [JsonProperty("sequence")]
        public int? Sequence { get; set; }

        [Required, Description("شماره پایانه"), MinLength(8), MaxLength(8)]
        [JsonProperty("terminalNumber")]
        public string TerminalNumber { get; set; }

        /// <summary>
        /// طبق جدول 9-5 مستند شاپرک
        /// </summary>
        [Required, Description("نوع پایانه")]
        [JsonProperty("terminalType")]
        public ShaparakTerminalType TerminalType { get; set; }

        [Description("سریال سخت افزار پایانه")]
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [Required, Description("تاریخ فعال سازی")]
        [JsonProperty("setupDate")]
        public long SetupDate => SetupDateValue.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="SetupDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [JsonIgnore]
        public DateTime SetupDateValue { get; set; }

        [Description("برند سخت افزار پایانه"), MaxLength(50)]
        [JsonProperty("hardwareBrand")]
        public string HardwareBrand { get; set; }

        [Description("مدل سخت افزار پایانه"), MaxLength(50)]
        [JsonProperty("hardwareModel")]
        public string HardwareModel { get; set; }

        /// <summary>
        /// این فیلد برای درگاه اینترنتی اجباری است و
        /// در سایر موارد مقدار نال دارد
        /// </summary>
        [Description("آدرس وب سایت استفاده کننده از درگاه اینترنتی"), MaxLength(100)]
        [JsonProperty("accessAddress")]
        public string AccessAddress { get; set; }

        /// <summary>
        /// این فیلد برای درگاه اینترنتی اجباری و 
        /// در سایر موارد مقدار نال می گیرد.
        /// </summary>
        [Description("پورت وب سایت استفاده کننده از درگاه اینترنتی")]
        [JsonProperty("accessPort")]
        public int AccessPort { get; set; }

        /// <summary>
        /// این فیلد برای وب سایت احباری است و 
        /// در سایر موارد مقدار نال می گیرد.
        /// </summary>
        [Description("آدرس کال بک درگاه"), MinLength(7), MaxLength(100)]
        [JsonProperty("callbackAddress")]
        public string CallbackAddress { get; set; }

        [Description("پورت کال بک درگاه")]
        [JsonProperty("callbackPort")]
        public int CallbackPort { get; set; }

        /// <summary>
        /// مقادیر سایر فیلدهای این مستند نباید در این
        /// فیلد ارسال شوند.همچنین اطلاعات ارسالی در این
        /// فیلد به منزله اطلاع رسانی رسمی به شاپرک نمی باشد
        /// </summary>
        [Description("توضیحات"), MaxLength(255)]
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// هنگام ثبت درخواست اصلاح اطلاعات این فیلد با مقدار لازم پر می شود
        /// در غیر این صورت null.
        /// ص69 مستند وب سرویس شاپرک
        /// </summary>
        [JsonProperty("updateAction")]
        public ShaparakUpdateAction? UpdateAction { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
