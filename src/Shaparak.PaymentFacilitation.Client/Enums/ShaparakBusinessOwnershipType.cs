using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Core.Enums {

    /// <summary>
    /// نوع مالکیت کسب و کار
    /// </summary>
    public enum ShaparakBusinessOwnershipType {

        [Description("مالک")]
        Owner = 0,
        
        [Description("مستاجر")]
        Tenant = 1
    }
}
