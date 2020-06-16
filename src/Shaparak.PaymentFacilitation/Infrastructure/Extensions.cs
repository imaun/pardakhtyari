using Newtonsoft.Json;

namespace Shaparak.PaymentFacilitation  {

    public static class Extensions {

        public static string SerializeToString(this object model) 
            => JsonConvert.SerializeObject(model, Formatting.Indented);
        
    }
}
