using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Enums {
    
    /// <summary>
    /// انواع امکان تقسیم وجوه
    /// جدول 29-5-5 ص73 مستند وب سرویس شاپرک
    /// </summary>
    public enum ShaparakScatteredSettlementType {

        [Description("عدم امکان تقسیم وجوه")]
        NotAllowed = 0,

        [Description("امکان تقسیم وجوه در یک بانک")]
        AllowedInOneBankOnly = 1,
        
        [Description("امکان تقسیم وجوه در بانک های مختلف")]
        AllowedInDifferentBanks = 2
    }
}
