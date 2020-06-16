using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Enums {

    /// <summary>
    /// نوع جنسیت در سیستم شاپرک
    /// </summary>
    public enum ShaparakGender {
        
        [Description("زن")]
        Female = 0,

        [Description("مرد")]
        Male = 1
    }
}
