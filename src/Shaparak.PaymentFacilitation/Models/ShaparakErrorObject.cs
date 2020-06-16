using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation.Models {

    /// <summary>
    /// جدول 18-5-5 مستند شاپرک
    /// نوع خطا
    /// لیست کامل کدهای خطای سامانه جهت اطلاع شرکت های پرداخت یار و اعمال ی پیاده سازی در قالب مستندی مستقل به
    /// شرکت ها ارائه می گردد.
    /// </summary>
    public class ShaparakErrorObject {

        /// <summary>
        /// Error! Reference source not found.
        /// </summary>
        [Description("کد خطا")]
        [JsonProperty("codeExceptionValue")]
        public int CodeExceptionValue { get; set; }

        /// <summary>
        /// جدول 32-5 مستند وب سرویس شاپرک.
        /// معنی شماره خطا.
        /// </summary>
        public ShaparakCodeExceptions CodeException 
            => (ShaparakCodeExceptions) CodeExceptionValue;

        /// <summary>
        /// این بخش صرفاً در مواردی که خطا مربوط به فیلد خاصی باشد پر می شود
        /// </summary>
        [Description("فیلد دارای خطا"), MaxLength(50)]
        public string FieldName { get; set; }
        
    }
}
