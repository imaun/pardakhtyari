using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Enums;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// مدل ثبت درخواست توسط پرداخت یار در وب سرویس شاپرک.
    /// ص14 مستند وب سرویس شاپرک.
    /// انواع درخواست های تعریف پذیرنده، ترمینال، تغییر آدرس، تعریف مشتری و ...
    /// طبق انواع درخواست <see cref="ShaparakRequestType"/>
    /// برای راهنمایی بیشتر در خصوص انواع درخواست ها به پیوست 1 مستند 
    /// پروتکل وب سرویس‌های ثبت و پیگیری درخواست‌های متقضایان در سامانه جامع پذیرندگان توسط شرکت‌های پرداخت‌یار مراجعه کنید
    /// </summary>
    public class ShaparakWriteRequest {

        /// <summary>
        /// شماره پیگیری شرکت پرداخت
        /// برای درخواست های ثبت شده توسط شرکت پرداخت
        /// </summary>
        [Required, Description("شماره پیگیری شرکت پرداخت")]
        [JsonProperty("trackingNumberPsp")]
        public string PspTrackingNumber { get; set; }

        /// <summary>
        /// نوع درخواست
        /// جدول 7-5
        /// </summary>
        [Required, Description("نوع درخواست")]
        [JsonProperty("requestType")]
        public ShaparakRequestType RequestType { get; set; }

        /// <summary>
        /// اطلاعات متقاضی 
        /// جدول 8-5 مستند شاپرک
        /// </summary>
        [Required, Description("اطلاعات متقاضی")]
        [JsonProperty("merchant")]
        public ShaparakMerchant Merchant { get; set; }

        /// <summary>
        /// اطلاعات شرکای متقاضی
        /// جدول 24-5 و 6-5
        ///در صورت نیاز به تخصیص شبایی به پذیرنده که متعلق به شخص دیگری می باشد
        ///این شخص به عنوان مشتری در سیستم ثبت شده و اطلاعات وی در این بخش ارسال می شود
        /// تمامی شرکای متقاضی نیز حتی در صورت نداشتن ابزار پرداخت، به طور خودکار در سامانه به صورت مشتری تعریف می شوند
        /// </summary>
        [JsonProperty("relatedMerchants")]
        public List<ShaparakRelatedMerchant> RelatedMerchants { get; set; }

        /// <summary>
        /// اطلاعات قرارداد
        /// در درخواست های اعمال محدودیت، تکمیل اطلاعات و ثبت کاربر، در سایر درخواست هایی که شرکت
        /// ارائه دهنده خدمات پرداخت ثبت می کند اجباری است
        /// </summary>
        [JsonProperty("Contract")]
        public ShaparakContractInfo Contract { get; set; }

        /// <summary>
        /// اطلاعات فروشگاه های متقاضی جدول 26-5 مستند وب سرویس شاپرک.
        /// فقط اطلاعات فروشگاه هایی که طی این درخواست متاثر می‌شوند آورده می شوند.
        /// برای درخواست های تعریف/تغییر/حذف شبای عمومی، اعمال محدودیت و تعریف کاربر،
        /// الزاماً این مورد نال فرستاده شود.
        /// </summary>
        [JsonProperty("pspRequestShopAcceptors")]
        public List<ShaparakShopAndAcceptor> ShopAcceptors { get; set; }

        /// <summary>
        /// مقادیر سایر فیلدهای این مستند نباید در این
        /// فیلد ارسال شوند.همچنین اطلاعات ارسالی در این
        /// فیلد به منزله اطلاع رسانی رسمی به شاپرک نمی باشد
        /// </summary>
        [Description("توضیحات"), MaxLength(255)]
        [JsonProperty("Description")]
        public string Description { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
