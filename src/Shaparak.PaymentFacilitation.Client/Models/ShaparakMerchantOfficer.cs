using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Enums;
using Shaparak.PaymentFacilitation.Core.Infrastructure;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// اطلاعات صاحبان امضاء برای سازمان ها
    /// </summary>
    public class ShaparakMerchantOfficer {

        /// <summary>
        /// این مورد برای صاحبان امضاء غیر ایرانی اجباری است
        /// برای صاحبان امضاء حقیقی ایرانی با توجه به  داده های برگشتی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("نام"), MaxLength(50)]
        [JsonProperty("firstNameFa")]
        public string FirstNameFa { get; set; }

        /// <summary>
        /// این مورد برای صاحبان امضاء غیر ایرانی اجباری است
        /// برای صاحبان امضاء حقیقی ایرانی با توجه به  داده های برگشتی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("نام خانوادگی"), MaxLength(50)]
        [JsonProperty("lastNameFa")]
        public string LastNameFa { get; set; }

        /// <summary>
        /// برای صاحبان امضاء حقیقی ایرانی با توجه به  داده های برگشتی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("نام پدر"), MaxLength(50)]
        [JsonProperty("fatherNameFa")]
        public string FatherNameFa { get; set; }

        /// <summary>
        /// نام به انگلیسی
        /// برای صاحبان امضاء حقیقی اجباری
        /// </summary>
        [Description("نام به انگلیسی"), MaxLength(50)]
        [JsonProperty("firstNameEn")]
        public string FirstNameEn { get; set; }

        /// <summary>
        /// نام خانوادگی به انگلیسی
        /// برای صاحبان امضاء حقیقی اجباری
        /// </summary>
        [Description("نام خانوادگی به انگلیسی"), MaxLength(50)]
        [JsonProperty("lastNameEn")]
        public string LastNameEn { get; set; }

        /// <summary>
        ///  برای صاحبان امضاء حقیقی ایرانی اجباری است
        /// </summary>
        [Description("نام پدر به انگلیسی"), MaxLength(50)]
        [JsonProperty("fatherNameEn")]
        public string FatherNameEn { get; set; }

        /// <summary>
        /// طبق جدول 5-28 مستند
        /// برای صاحبان امضاء غیرایرانی اجباری
        /// برای صاحبان امضاء حقیقی ایرانی، طبق داده های برگشتی از استعلام ثبت احول تکمیل می شود
        /// </summary>
        [Description("جنسیت")]
        [JsonProperty("gender")]
        public ShaparakGender? Gender { get; set; }

        /// <summary>
        /// برای متقاضی حقیقی اجباری
        /// سایر موارد مقدار null
        /// </summary>
        [Description("تاریخ تولد")]
        [JsonProperty("birthDate")]
        public long? BirthDate => BirthDateValue?.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="BirthDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [JsonIgnore]
        public DateTime? BirthDateValue { get; set; }

        /// <summary>
        /// برای متقاضی حقیقی ایرانی اجباری
        /// سایر موارد مقدار null
        /// </summary>
        [Description("کد ملی"), MaxLength(10)]
        [JsonProperty("nationalCode")]
        public string NationalCode { get; set; }

        /// <summary>
        /// ایرانی یا غیرایرانی
        /// طبق جدول 5-19 مستند شاپرک
        /// </summary>
        [Required, Description("ملیت متقاضی")]
        [JsonProperty("residencyType")]
        public ShaparakResidencyType ResidencyType { get; set; }

        /// <summary>
        /// زنده یا مرده!!
        /// طبق جدول 5-20 مستند شاپرک
        /// برای صاحبان امضاء حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("وضعیت حیات")]
        [JsonProperty("vitalStatus")]
        public ShaparakVitalStatus? VitalStatus { get; set; }

        /// <summary>
        /// برای صاحبان امضاء حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("شماره شناسنامه")]
        [JsonProperty("birthCrtfctNumber")]
        public int? BirthCertificateNumber { get; set; }

        /// <summary>
        /// برای صاحبان امضاء حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("سریال شناسنامه")]
        [JsonProperty("birthCrtfctSerial")]
        public int? BirthCertificateSerial { get; set; }

        /// <summary>
        /// طبق جدول 5-29 مستند شاپرک
        /// برای صاحبان امضاء حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("بخش حرفی سری شناسنامه")]
        [JsonProperty("birthCrtfctSeriesLetter")]
        public ShaparakIdCertificateLetter? BirthCertificateSeriesLetter { get; set; }

        /// <summary>
        ///برای صاحبان امضاء حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود  
        /// </summary>
        [Description("بخش عددی سری شناسنامه")]
        [JsonProperty("birthCrtfctSeriesNumber")]
        public int? BirthCertificateSeriesNumber { get; set; }

        /// <summary>
        /// برای صاحبان امضاء غیرایرانی اجباری
        /// </summary>
        [Description("کد کشور"), MaxLength(2)]
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// برای صاحبان امضاء غیر ایرانی اجباری
        /// اعتبارسنجی در سامانه جامع کنترل می شود
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("شناسه فراگیر اتباع خارجی"), MaxLength(50)]
        [JsonProperty("foreignPervasiveCode")]
        public string ForeignPervasiveCode { get; set; }

        /// <summary>
        /// این مورد برای صاحبان امضاء غیرایرانی اجباری
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("شماره گذرنامه"), MaxLength(50)]
        [JsonProperty("passportNumber")]
        public string PassportNumber { get; set; }

        /// <summary>
        /// برای صاحبان امضاء غیرایرانی اجباری
        /// در سایر موارد null
        /// </summary>
        [Description("تاریخ اتمام اعتبار گذرنامه")]
        [JsonProperty("passportExpireDate")]
        public long? PassportExpireDate => PassportExpireDateValue?.ToTimestamp3();
        
        /// <summary>
        /// Backing field for : <see cref="PassportExpireDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [JsonIgnore]
        public DateTime? PassportExpireDateValue { get; set; }

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
