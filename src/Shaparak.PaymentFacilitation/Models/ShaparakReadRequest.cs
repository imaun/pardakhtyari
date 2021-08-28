using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using Shaparak.PaymentFacilitation.Enums;
using Shaparak.PaymentFacilitation.Infrastructure;

namespace Shaparak.PaymentFacilitation.Models {

    /// <summary>
    /// قالب تقاضای دریافت درخواست های مرتبط با سامانه.
    /// حداقل یکی از سه فیلد requestDate, trackingNumbers, trackingNumbersPsps باید دارای مقدار باشد.
    /// حداکثر بازه زمانی مورد قبول یک روز.
    /// حداکثر امکان جستجو بر اساس 100 شماره پیگیری یا 100 شماره پیگیری پرداخت یار.
    /// در صورت عدم رعایت شرایط فوق هیچ داده ای بازگردانده نمی‌شود.
    /// </summary>
    public class ShaparakReadRequest {

        #region Sample Request
        /*
         * نمونه درخواست وب سرویس جستجوی درخواست
        { 
            "requestDate": null,
            "requestTypes" : null,
            "statuses": null,
            "trackingNumbers": [ "154986587429854", "154986587429854", "564654654654487" ], 
            "trackingNumberPsps": null 
        }
        */
        #endregion

        /// <summary>
        /// برای تعیین شروع بازه درخواست  این فیلد را مقداردهی کنید.
        /// </summary>
        [JsonIgnore]
        public DateTime RequestStartDateValue { get; set; }

        /// <summary>
        /// برای تعیین تاریخ پایان بازه درخواست این فیلد را مقداردهی کنید.
        /// </summary>
        [JsonIgnore]
        public DateTime RequestFinishDateValue { get; set; }


        private List<long> requestDate;
        /// <summary>
        /// آرایه ای دو عضوی از نوع Timestamp
        /// که عضو اول تاریخ ابتدای بازه و  عضو دوم تاریخ انتهای بازه را نشان می‌دهد.
        /// (توجه کنید که مقادیر شروع و پایان از فیلد های <see cref="RequestStartDateValue"/> و <see cref="RequestFinishDateValue"/>
        /// خوانده می‌شود)
        /// </summary>
        [Description("بازه شروع و پایان تاریخ درخواست")]
        [JsonProperty("requestDate")]
        public List<long> RequestDate { 
            get {
                if (requestDate != null && requestDate.Any())
                    return requestDate;

                return new List<long> {
                        RequestStartDateValue.ToTimestamp3(),
                        RequestFinishDateValue.ToTimestamp3()
                };
            }
            set => requestDate = value;
        }

        
        /// <summary>
        /// آرایه ای از نوع درخواست
        /// جدول 7-5 مستند شاپرک
        /// </summary>
        [Description("نوع درخواست")]
        [JsonProperty("requestTypes")]
        public List<ShaparakRequestType> RequestTypes { get; set; }

        /// <summary>
        /// آرایه ای از وضعیت درخواست ها
        /// جدول 5-7 مستند شاپرک
        /// </summary>
        [Description("وضعیت درخواست")]
        [JsonProperty("statuses")]
        public List<ShaparakRequestStatus> Statuses { get; set; }

        /// <summary>
        /// آرایه ای از شماره پیگیری درخواست های ثبت شده
        /// </summary>
        [Description("شماره های پیگیری شاپرک")]
        [JsonProperty("trackingNumbers")]
        public List<string> TrackingNumbers { get; set; }

        /// <summary>
        /// آرایه ای از شماره پیگیری درخواست های ثبت شده شرکت پرداخت
        /// </summary>
        [Description("شماره های پیگیری Psp")]
        [JsonProperty("trackingNumbersPsps")]
        public List<string> PspTrackingNumbers { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
