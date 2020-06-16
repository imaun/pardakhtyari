using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Enums;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// اقلام اطلاعاتی پذیرندگی
    /// (جدول 5-5-28)
    /// مستند وب سرویس شاپرک
    /// </summary>
    public class ShaparakAcceptor {

        [Required, Description("کد سوئیچ شرکت پرداخت"), MinLength(6), MaxLength(9)]
        [JsonProperty("iin")]
        public string Iin { get; set; }

        [Required, Description("کد پذیرنده"), MinLength(15), MaxLength(15)]
        [JsonProperty("acceptorCode")]
        public string AcceptorCode { get; set; }

        [Required, Description("نوع پذیرندگی")]
        public ShaparakAcceptorType AcceptorType { get; set; }

        /// <summary>
        /// این کد از شرکت Psp برای ما ارسال می‌شود و در درخواست های مربوط به همان Psp همیشه یک عدد 15رقمی یکسان است.
        /// </summary>
        [Description("کد پذیرنده پرداخت یار"), MinLength(15), MaxLength(15)]
        [JsonProperty("facilitatorAcceptorCode")]
        public string FacilitatorAcceptorCode { get; set; }

        [Required, Description("امکان لغو تراکنش")]
        [JsonProperty("cancelable")]
        public bool Cancelable { get; set; }

        [Required, Description("امکان برگشت وجه به دارنده کارت")]
        [JsonProperty("refundable")]
        public bool Refundable { get; set; }
        
        /// <summary>
        /// امکان مسدود کردن حساب به میزان مبلغ تراکنش
        /// </summary>
        [Required, Description("امکان مسدود کردن حسابک")]
        [JsonProperty("blockable")]
        public bool Blockable { get; set; }

        [Required, Description("امکان عملیات ChargeBack")]
        [JsonProperty("chargeBackable")]
        public bool ChargeBackable { get; set; }

        /// <summary>
        /// امکان واریز تفکیکی وجوه
        /// استفاده آتی
        /// </summary>
        [Required, Description("امکان واریز تفکیکی وجوه")]
        public bool SettledSeparately { get; set; }

        /// <summary>
        /// امکان تقسیم وجوه
        /// (استفاده آتی)
        /// </summary>
        [Required, Description("امکان تقسیم وجوه")]
        [JsonProperty("allowScatteredSettlement")]
        public ShaparakScatteredSettlementType AllowScatteredSettlement { get; set; }

        /// <summary>
        /// (استفاده آتی)
        /// </summary>
        [Required, Description("امکان پذیرش کارت اعتباری")]
        [JsonProperty("acceptCreditCardTransaction")]
        public bool AcceptCreditCardTransaction { get; set; }

        [Required, Description("امکان ارسال تراکنش خرید کالای ایرانی")]
        [JsonProperty("allowIranianProductsTrx")]
        public bool AllowIranianProductsTrx { get; set; }

        [Required, Description("امکان ارسال تراکنش کارا کارت")]
        [JsonProperty("allowKaraCardTrx")]
        public bool AllowKaraCardTrx { get; set; }

        [Required, Description("امکان ارسال تراکنش سبد کالا")]
        [JsonProperty("allowGoodsBasketTrx")]
        public bool AllowGoodsBasketTrx { get; set; }

        [Required, Description("امکان ارسال تراکنش امنیت غذایی")]
        [JsonProperty("AllowFoodSecurityTrx")]
        public bool AllowFoodSecurityTrx { get; set; }

        [Required, Description("امکان پذیرش کارت های UPI")]
        [JsonProperty("AllowUpiCardTrx")]
        public bool AllowUpiCardTrx { get; set; }

        [Required, Description("امکان پذیرش کارت های Visa")]
        [JsonProperty("AllowVisaCardTrx")]
        public bool AllowVisaCardTrx { get; set; }

        [Required, Description("امکان پذیرش کارت های MasterCard")]
        [JsonProperty("AllowMasterCardTrx")]
        public bool AllowMasterCardTrx { get; set; }

        [Required, Description("امکان پذیرش کارت های American Express")]
        [JsonProperty("AllowAmericanExpressTrx")]
        public bool AllowAmericanExpressTrx { get; set; }

        /// <summary>
        /// اشتباه تایپی در دیتا ممبر در مستند شاپرک بوده!!
        /// L انتهای کلمه International در نام فیلد در مستند هست
        /// امیدوارم که اررور نده
        /// </summary>
        [Required, Description("امکان پذیرش کارت های سایر موسسات بین المللی")]
        [JsonProperty("AllowOtherInternationaCardsTrx")]
        public bool AllowOtherInternationalCardsTrx { get; set; }

        /// <summary>
        /// این مورد در مستندات شاپرک ذکر نشده!
        /// موقع ثبت اولین پذیرنده در محیط عملیاتی با خطای عدم وجود این فیلد در درخواست مواجه شدم که خودم اضافه کردم و خطا برطرف شد.
        /// [imun]
        /// </summary>
        [Required, Description("امکان پذیرش تراکنش های Jcb!")]
        public bool AllowJcbCardTrx { get; set; }

        /// <summary>
        /// پایانه های مربوط به پذیرندگی
        /// (جدول 5-12) مستند وب سرویس شاپرک
        /// </summary>
        [Required, Description("پایانه های مربوط به پذیرندگی")]
        [JsonProperty("terminals")]
        public List<ShaparakTerminal> Terminals { get; set; }

        /// <summary>
        /// شباهای متصل به پذیرندگی جهت فرآیند تسویه داخلی شاپرک
        /// * این نوع شبا صرفا برای پذیرندگان "پشتیبانی شده" و در درخواست‌های "تعریف ترمینال" و "تغییر شبا" اجباری است
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("شباهای متصل به پذیرندگی")]
        [JsonProperty("shaparakSettlementIbans")]
        public List<string> ShaparakSettlementIbans { get; set; }

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
