using System.ComponentModel;

namespace Shaparak.PaymentFacilitation.Enums {
    
    public enum ShaparakVitalStatus {
        
        [Description("در قید حیات")]
        InLife = 0,
        
        [Description("فوت شده")]
        Departed = 1
    }
}
