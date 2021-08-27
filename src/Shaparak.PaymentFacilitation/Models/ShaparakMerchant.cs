using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Enums;
using Shaparak.PaymentFacilitation.Infrastructure;

namespace Shaparak.PaymentFacilitation.Models {

    /// <summary>
    /// اقلام اطلاعاتی متقاضی
    /// مقادیر پنج فیلد نوع متقاضی، ملیت متقاضی، کد ملی، شناسه ملی اشخاص حقوقی، شناسه فراگیر اتباع خارجی برای این جدول
    /// به عنوان کلید تلقی می گردد.
    /// بسته به مقادیر دو فیلد نوع متقاضی و ملیت متقاضی، فاط یکی از سه فیلد کد ملی، شناسه ملی اشخاص حقوقی و شناسه فراگیر
    /// اتباع خارجی، برای هر متقاضی،مقدار می گیرند و مقدار دو فیلد دیگر null می باشد.
    /// </summary>
    public class ShaparakMerchant {

        /// <summary>
        /// این مورد برای متقاضیان غیر ایرانی اجباری است
        /// برای متقاضیان حقیقی ایرانی با توجه به  داده های برگشتی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("نام"), MaxLength(50)]
        [JsonProperty("firstNameFa")]
        public string FirstNameFa { get; set; }

        /// <summary>
        /// این مورد برای متقاضیان غیر ایرانی اجباری است
        /// برای متقاضیان حقیقی ایرانی با توجه به  داده های برگشتی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("نام خانوادگی"), MaxLength(50)]
        [JsonProperty("lastNameFa")]
        public string LastNameFa { get; set; }

        /// <summary>
        /// برای متقاضیان حقیقی ایرانی با توجه به  داده های برگشتی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("نام پدر"), MaxLength(50)]
        [JsonProperty("fatherNameFa")]
        public string FatherNameFa { get; set; }

        /// <summary>
        /// نام به انگلیسی
        /// برای متقاضیان حقیقی اجباری
        /// </summary>
        [Description("نام به انگلیسی"), MaxLength(50)]
        [JsonProperty("firstNameEn")]
        public string FirstNameEn { get; set; }

        /// <summary>
        /// نام خانوادگی به انگلیسی
        /// برای متقاضیان حقیقی اجباری
        /// </summary>
        [Description("نام خانوادگی به انگلیسی"), MaxLength(50)]
        [JsonProperty("lastNameEn")]
        public string LastNameEn { get; set; }

        /// <summary>
        ///  برای متقاضیان حقیقی ایرانی اجباری است
        /// </summary>
        [Description("نام پدر به انگلیسی"), MaxLength(50)]
        [JsonProperty("fatherNameEn")]
        public string FatherNameEn { get; set; }

        /// <summary>
        /// طبق جدول 5-28 مستند
        /// برای متقاضیان غیرایرانی اجباری
        /// برای متقاضیان حقیقی ایرانی، طبق داده های برگشتی از استعلام ثبت احول تکمیل می شود
        /// </summary>
        [Description("جنسیت")]
        [JsonProperty("gender")]
        public ShaparakGender? Gender { get; set; }

        private long? birthDate;
        /// <summary>
        /// *Read Only : this will read the value of <see cref="BirthDateValue"/> and
        /// convert it to Timestamp*
        /// برای متقاضی حقیقی اجباری
        /// سایر موارد مقدار null
        /// </summary>
        [Description("تاریخ تولد")]
        [JsonProperty("birthDate")]
        public long? BirthDate {
            get {
                if (birthDate.HasValue)
                    return birthDate;

                return BirthDateValue?.ToTimestamp3();
            }
            set => birthDate = value;
        }

        /// <summary>
        /// Backing field for <see cref="BirthDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [JsonIgnore]
        public DateTime? BirthDateValue { get; set; }

        private long? registerDate;
        /// <summary>
        /// *Read Only : this will read the value of <see cref="RegisterDateValue"/> and
        /// convert it to Timestamp*
        /// برای متقاضی حقوقی اجباری
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("تاریخ ثبت متقاضی حقوقی")]
        [JsonProperty("registerDate")]
        public long? RegisterDate {
            get {
                if (registerDate.HasValue)
                    return registerDate;

                return RegisterDateValue?.ToTimestamp3();
            }
        }

        /// <summary>
        /// Backing field for <see cref="RegisterDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [JsonIgnore]
        public DateTime? RegisterDateValue { get; set; }

        /// <summary>
        /// برای متقاضی حقیقی ایرانی اجباری
        /// سایر موارد مقدار null
        /// </summary>
        [Description("کد ملی"), MaxLength(10)]
        [JsonProperty("nationalCode")]
        public string NationalCode { get; set; }

        [Description("شماره ثبت شرکت")]
        [JsonProperty("registerNumber"), MaxLength(50)]
        public string RegisterNumber { get; set; }

        /// <summary>
        /// برای متقاضی حقوقی اجباری
        /// سایر موارد مقدار null
        /// </summary>
        [Description("نام شرکت"), MaxLength(50)]
        [JsonProperty("comNameFa")]
        public string CompanyNameFa { get; set; }

        /// <summary>
        /// برای متقاضی حقوقی اجباری
        /// سایر موارد مقدار null
        /// </summary>
        [Description("نام شرکت به انگلیسی"), MaxLength(50)]
        [JsonProperty("comNameEn")]
        public string CompanyNameEn { get; set; }

        /// <summary>
        ///نوع متقاضی : حقیقی یا حقوقی
        ///طبق جدول 5-18 مستند شاپرک
        /// </summary>
        [Required, Description("نوع متقاضی")]
        [JsonProperty("merchantType")]
        public ShaparakMerchantIdentityType MerchantType { get; set; }

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
        /// برای متقاضیان حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("وضعیت حیات")]
        [JsonProperty("vitalStatus")]
        public ShaparakVitalStatus? VitalStatus { get; set; }

        /// <summary>
        /// برای متقاضیان حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("شماره شناسنامه"), MaxLength(10)]
        [JsonProperty("birthCrtfctNumber")]
        public int? BirthCertificateNumber { get; set; }

        /// <summary>
        /// برای متقاضیان حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("سریال شناسنامه"), MaxLength(6)]
        [JsonProperty("birthCrtfctSerial")]
        public int? BirthCertificateSerial { get; set; }

        /// <summary>
        /// طبق جدول 5-29 مستند شاپرک
        /// برای متقاضیان حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود
        /// </summary>
        [Description("بخش حرفی سری شناسنامه")]
        [JsonProperty("birthCrtfctSeriesLetter")]
        public ShaparakIdCertificateLetter? BirthCertificateSeriesLetter { get; set; }

        /// <summary>
        ///برای متقاضیان حقیقی ایرانی از استعلام اداره ثبت احوال تکمیل می شود  
        /// </summary>
        [Description("بخش عددی سری شناسنامه"), MaxLength(2)]
        [JsonProperty("birthCrtfctSeriesNumber")]
        public int? BirthCertificateSeriesNumber { get; set; }

        /// <summary>
        /// برای متقاضی حقوقی اجباری
        /// اعتبارسنجی آن در سامانه جامع کنترل می شود
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("شناسه ملی اشخاص حقوقی"), MaxLength(11)]
        [JsonProperty("nationalLegalCode")]
        public string NationalLegalCode { get; set; }

        [Description("کد اقتصادی"), MaxLength(50)]
        [JsonProperty("commercialCode")]
        public string CommercialCode { get; set; }

        /// <summary>
        /// برای متقاضیان غیرایرانی اجباری
        /// </summary>
        [Description("کد کشور"), MaxLength(2)]
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// برای متقاضیان غیر ایرانی اجباری
        /// اعتبارسنجی در سامانه جامع کنترل می شود
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("شناسه فراگیر اتباع خارجی"), MaxLength(50)]
        [JsonProperty("foreignPervasiveCode")]
        public string ForeignPervasiveCode { get; set; }

        /// <summary>
        /// این مورد برای متقاضیان غیرایرانی اجباری
        /// در سایر موارد مقدار null
        /// </summary>
        [Description("شماره گذرنامه"), MaxLength(50)]
        [JsonProperty("passportNumber")]
        public string PassportNumber { get; set; }

        private long? passportExpireDate;
        /// <summary>
        /// برای متقاضیان غیرایرانی اجباری
        /// در سایر موارد null
        /// </summary>
        [Description("تاریخ اتمام اعتبار گذرنامه")]
        [JsonProperty("passportExpireDate")]
        public long? PassportExpireDate {
            get {
                if (passportExpireDate.HasValue)
                    return passportExpireDate;

                return PassportExpireDateValue?.ToTimestamp3();
            }
        }
        
        /// <summary>
        /// Backing field for <see cref="PassportExpireDate"/>
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

        [Required, Description("شماره تلفن  ثابت"), MinLength(9), MaxLength(12)]
        [JsonProperty("telephoneNumber")]
        public string TelephoneNumber { get; set; }

        [Required, Description("تلفن همراه"), MinLength(11), MaxLength(11)]
        [JsonProperty("cellPhoneNumber")]
        public string Mobile { get; set; }

        [Description("آدرس پست الکترونیکی"), MaxLength(100)]
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [Description("آدرس وب سایت"), MaxLength(100)]
        [JsonProperty("webSite")]
        public string Website { get; set; }

        [Description("شماره نمابر"), MaxLength(12)]
        [JsonProperty("fax")]
        public string Fax { get; set; }

        /// <summary>
        /// جدول 11-5 مستند شاپرک
        /// بر اساس قانون شاپرک
        /// هر شبای تعریف شده در سیستم الزاما متعلق به یک و فقط یک مشتری می باشد.
        /// </summary>
        [Required, Description("اطلاعات شباهای متقاضی")]
        [JsonProperty("merchantIbans")]
        public List<ShaparakMerchantIbanInfo> Ibans { get; set; }

        /// <summary>
        /// برای متقاضیان حقوقی اجباری
        /// سایر موارد null
        /// </summary>
        [Description("اطلاعات امضاء داران")]
        [JsonProperty("merchantOfficers")]
        public List<ShaparakMerchantOfficer> Officers { get; set; }

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
