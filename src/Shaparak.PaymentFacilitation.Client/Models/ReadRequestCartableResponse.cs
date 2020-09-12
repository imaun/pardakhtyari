using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Core.Enums;

namespace Shaparak.PaymentFacilitation.Core.Models {

    /// <summary>
    /// مدل نتیجه جستجو برای درخواست های ثبت شده در سامانه جامع پذیرندگان شاپرک
    /// </summary>
    public class ReadRequestCartableResponse {

        #region Sample Response

        /*
         [
            { 
                "trackingNumber"://value, 
                "trackingNumberPsp"://value, 
                "status": //value, 
                "requestDate" : //value, 
                "description" : //value,
                "requestType" ://value, 
                "merchant" : //value, 
                "relatedMerchants"://value, 
                "requestRejectionReasons" : //value, 
                "requestDetails"://value
            }
        ] */

        #endregion

        /// <summary>
        /// شماره پیگیری
        /// به عنوان شناسه پرداخت
        /// </summary>
        [Description("شماره پیگیری")]
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// شماره پیگیری شرکت پرداخت
        /// برای درخواست های ثبت شده توسط شرکت پرداخت
        /// </summary>
        [JsonProperty("trackingNumberPsp")]
        public string PspTrackingNumber { get; set; }

        /// <summary>
        /// وضعیت درخواست
        /// جدول 6-5 مستند شاپرک
        /// </summary>
        [JsonProperty("Status")]
        public ShaparakRequestStatus Status { get; set; }

        /// <summary>
        /// توضیحات از طرف ثبت کننده درخواست
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// نوع درخواست
        /// جدول 7-5
        /// </summary>
        [JsonProperty("requestType")]
        public ShaparakRequestType RequestType { get; set; }

        /// <summary>
        /// اطلاعات متقاضی 
        /// جدول 8-5 مستند شاپرک
        /// </summary>
        [JsonProperty("merchant")]
        public ShaparakMerchant Merchant { get; set; }

        /// <summary>
        /// اطلاعات شرکای متقاضی
        /// جدول 24-5 و 6-5
        /// </summary>
        [JsonProperty("relatedMerchants")]
        public List<ShaparakRelatedMerchant> RelatedMerchants { get; set; }

        /// <summary>
        /// دلایل رد/عدم پذیرش درخواست
        /// جدول 23-5 مستند شاپرک
        /// </summary>
        [JsonProperty("requestRejectionReasons")]
        public List<ShaparakErrorObject> RejectionReasons { get; set; }

        /// <summary>
        /// این فیلد جهت کاربردهای آتی در نظر گرفته شده
        /// </summary>
        [JsonProperty("requestDetails")]
        public object Details { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
