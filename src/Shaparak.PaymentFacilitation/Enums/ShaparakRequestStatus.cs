using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Enums {
    
    /// <summary>
    /// انواع وضعیت های درخواست در سیستم شاپرک
    /// </summary>
    public enum ShaparakRequestStatus {
        
        [Description("رد نهایی")]
        FinalRejection = 5,

        [Description("در انتظار ارائه سرویس درخواستی")]
        WaitingForService = 8,

        /// <summary>
        /// در مواردی قبیل در دسترس نبودن سرویس های استعلام هویتی و آدرس پستی و ...
        /// پردازش رکوردها تا زمان رفع مشکل به تاخیر خواهد افتاد
        /// </summary>
        [Description("تاخیر در پردازش")]
        DelayInProcessing = 12,

        [Description("تایید نهایی")]
        FinalAcceptance = 14
    }
}
