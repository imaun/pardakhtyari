using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Enums {

    /// <summary>
    /// وضعیت ترمینال پذیرندگی
    /// </summary>
    public enum ShaparakTerminalStatus {

        [Description("در انتظار فعال سازی")]
        Waiting = 0,

        [Description("فعال")]
        Active = 1,

        [Description("غیرفعال موقت به درخواست متقاضی")]
        TemporaryDisabledByMerchant = 2,

        [Description("غیرفعال موقت به درخواست سرویس دهنده")]
        TemporaryDisabledByServiceProvider = 3,

        [Description("غیرفعال موقت با تصمیم شاپرک")]
        TemporaryDisabledByShaparak = 4,

        [Description("جمع آوری به درخواست پذیرنده")]
        RemovedByMerchant = 5,

        [Description("غیرفعال سازی به درخواست سرویس دهنده")]
        DisabledByServiceProvider = 6,

        [Description("غیرفعال سازی با تصمیم شاپرک")]
        DisabledByShaparak = 7,
    }
}
