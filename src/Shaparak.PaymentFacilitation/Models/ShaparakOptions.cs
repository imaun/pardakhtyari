namespace Shaparak.PaymentFacilitation {
    /// <summary>
    /// تنظیمات اتصال به سرویس پرداخت‌یاری شاپرک
    /// </summary>
    public class ShaparakOptions
    {
        /// <summary>
        /// نام کاربری بدون رمزنگاری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///کلمه عبور بدون رمزنگاری
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Shaparak API BaseUrl. For production use : https://mms.shaparak.ir/merchant
        /// </summary>
        public string BaseUrl { get; set; }
    }
}
