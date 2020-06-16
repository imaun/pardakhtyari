using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Enums;
using Shaparak.PaymentFacilitation.Core.Infrastructure;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// توضیح مهم :
    /// سه قلم اطلاعاتی مشتری، کدپستی و صنف در موجودیت فروشگاه به عنوان کلید می باشند
    /// تعلق آدرس وب سایت اعلامی به فروشگاه در اطلاعات ارسالی بر عهده شرکت پرداخت می باشد
    /// این موضوع در ممیزی های شرکت شاپرک نیز لحاظ می شود
    /// </summary>
    public class ShaparakShop {

        [Required, Description("نام فارسی فروشگاه"), MinLength(1), MaxLength(50)]
        [JsonProperty("farsiName")]
        public string FarsiName { get; set; }

        [Required, Description("نام انگلیسی فروشگاه"), MinLength(1), MaxLength(50)]
        [JsonProperty("englishName")]
        public string EnglishName { get; set; }

        [Required, Description("شماره تلفن ثابت"), MinLength(9), MaxLength(12)]
        [JsonProperty("telephoneNumber")]
        public string TelephoneNumber { get; set; }

        [Required, Description("کد پستی"), MinLength(10), MaxLength(10)]
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [Description("شماره جواز کسب"), MaxLength(50)]
        [JsonProperty("businessCertificateNumber")]
        public string BusinessCertificateNumber { get; set; }

        [Description("تاریخ صدور جواز کسب")]
        [JsonProperty("certificateIssueDate")]
        public long? CertificateIssueDate => CertificateIssueDateValue?.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="CertificateIssueDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [IgnoreDataMember]
        public DateTime? CertificateIssueDateValue { get; set; }

        [Description("تاریخ اعتبار جواز کسب")]
        [JsonProperty("certificateExpiryDate")]
        public long? CertificateExpiryDate => CertificateExpiryDateValue?.ToTimestamp3();
        
        /// <summary>
        /// Backing field for : <see cref="CertificateExpiryDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        [IgnoreDataMember]
        public DateTime? CertificateExpiryDateValue { get; set; }

        /// <summary>
        /// مقادیر سایر فیلدهای این مستند نباید در این
        /// فیلد ارسال شوند.همچنین اطلاعات ارسالی در این
        /// فیلد به منزله اطلاع رسانی رسمی به شاپرک نمی باشد
        /// </summary>
        [Description("توضیحات"), MaxLength(255)]
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// رجوع به مستند دستورالعمل جامع تخصیص کد صنف
        /// به پذیرندگان شبکه الکترونیکی پرداخت کارت
        /// </summary>
        [Required, Description("کد صنف"), MinLength(4), MaxLength(4)]
        [JsonProperty("businessCategoryCode")]
        public string BusinessCategoryCode { get; set; }

        [Required, Description("businessSubCategoryCode"), MinLength(1), MaxLength(4)]
        [JsonProperty("businessSubCategoryCode")]
        public string BusinessSubCategoryCode { get; set; }

        [Description("wnershipType")]
        [JsonProperty("ownershipType")]
        public ShaparakBusinessOwnershipType OwnershipType { get; set; }

        /// <summary>
        /// برای فروشگاه هایی که نوع مالکیت استیجاری دارند
        /// این مورد اجباری است و در سایر موارد مقدار نال می گیرد
        /// </summary>
        [Description("rentalContractNumber"), MaxLength(50)]
        [JsonProperty("rentalContractNumber")]
        public string RentalContractNumber { get; set; }

        /// <summary>
        /// برای فروشگاه هایی که نوع مالکیت استیجاری دارند
        /// این مورد اجباری است و در سایر موارد مقدار نال می گیرد.
        /// </summary>
        [Description("تاریخ اتمام قرارداد اجاره")]
        [JsonProperty("rentalExpiryDate"),]
        public long? RentalExpiryDate => RentalExpiryDateValue?.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="RentalExpiryDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        public DateTime? RentalExpiryDateValue { get; set; }

        /// <summary>
        /// بر اساس کدپستی، استعلام آدرس از اداره پست
        /// </summary>
        [Description("آدرس"), MaxLength(255)]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [Required, Description("کد کشور"), MinLength(2), MaxLength(2)]
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// بر اساس کد پستی
        /// استعلام کد استان از اداره پست
        /// </summary>
        [Description("کد استان"), MaxLength(3)]
        [JsonProperty("provinceCode")]
        public string ProvinceCode { get; set; }

        [Description("کد شهر"), MaxLength(6)]
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [Required, Description("نوع فعالیت فروشگاه")]
        [JsonProperty("businessType")]
        public ShaparakShopType BusinessType { get; set; }

        /// <summary>
        /// بر اساس آدرس وب سایت
        /// استعلام نوع نماد اعتماد الکترونیکی از مرکز توسعه تجارت الکترونیکی
        /// </summary>
        [Description("نوع نماد اعتماد الکترونیکی")]
        [JsonProperty("etrustCertificateType")]
        public ShaparakEtrustCertificateType? EtrustCertificateType { get; set; }

        /// <summary>
        /// بر اساس آدرس وب سایت
        /// استعلام نوع نماد اعتماد الکترونیکی از مرکز توسعه تجارت الکترونیکی
        /// </summary>
        [Description("تاریخ صدور نماد اعتماد الکترونیکی")]
        [JsonProperty("etrustCertificateIssueDate")]
        public long? EtrustCertificateIssueDate => EtrustCertificateIssueDateValue?.ToTimestamp3();
        
        /// <summary>
        /// Backing field for : <see cref="EtrustCertificateExpiryDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        public DateTime? EtrustCertificateIssueDateValue { get; set; }

        [Description("تاریخ اتمام اعتبار نماد اعتماد الکترونیکی")]
        [JsonProperty("etrustCertificateExpiryDate")]
        public long? EtrustCertificateExpiryDate => EtrustCertificateExpiryDateValue?.ToTimestamp3();

        /// <summary>
        /// Backing field for : <see cref="EtrustCertificateExpiryDate"/>
        /// ----Important : Provide UTC DateTime for this field
        /// </summary>
        public DateTime? EtrustCertificateExpiryDateValue { get; set; }

        /// <summary>
        /// برای فروشگاه های مجازی اجباری
        /// و در غیر این صورت اختیاری
        /// </summary>
        [Description("آدرس پست الکترونیکی"), MinLength(6), MaxLength(255)]
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// برای فروشگاه های مجازی اجباری
        /// و در غیر این صورت اختیاری
        /// </summary>
        [Description("آدرس وب سایت"), MinLength(6), MaxLength(255)]
        [JsonProperty("websiteAddress")]
        public string WebsiteAddress { get; set; }

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
