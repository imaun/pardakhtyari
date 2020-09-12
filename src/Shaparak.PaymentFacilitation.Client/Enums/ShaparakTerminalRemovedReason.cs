using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Core.Enums {
    
    /// <summary>
    /// علل جمع آوری  پایانه
    /// جدول (5-5-9) مستند شاپرک ص52
    /// </summary>
    public enum ShaparakTerminalRemovedReason {

        [Description("اتمام فعالیت")]
        BusinessOut = 0,

        [Description("ضعف خدمات ارائه دهنده سرویس")]
        ServiceProviderWeakness = 1,

        [Description("عدم نیاز")]
        NoNeed = 2,

        [Description("سایر دلایل")]
        OtherReasons = 3
    }
}
