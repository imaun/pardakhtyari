using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Enums {
    
    /// <summary>
    /// نوع ارتباط تجاری دو متقاضی
    /// </summary>
    public enum ShaparakBusinessRelationshipType {
        [Description("تقسیم وجوه")]
        Split = 0,

        [Description("نماینده رسمی")]
        Official = 1
    }
}
