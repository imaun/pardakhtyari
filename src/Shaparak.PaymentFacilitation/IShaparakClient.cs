using System.Threading.Tasks;
using Shaparak.PaymentFacilitation.Models;

namespace Shaparak.PaymentFacilitation {

    /// <summary>
    /// کلاینت ارتباط با وب سرویس شاپرک
    /// دو متد کلی شاپرک را در اختیار می گذارد
    /// </summary>
    public interface IShaparakClient {
        /// <summary>
        /// Shaparak API BaseUrl.
        /// For production use the url must be : https://mms.shaparak.ir/merchant
        /// but make sure by reading the Shaparak docs.
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// Shaparak Username
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Shaparak Password
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// این متد برای جستجوی درخواست های ثبت شده شما می باشد.
        /// لطفاً برای راهنمایی بیشتر، به آدرس 
        /// https://virgool.io/@imun/pardakhtyari-nnnvvxpnyyay
        /// بروید
        /// </summary>
        /// <param name="model">مدل جستجوی درخواست ها</param>
        /// <returns></returns>
        Task<ShaparakReadRequestCartableResponse> ReadRequestCartableAsync(ShaparakReadRequest model);

        /// <summary>
        /// این متد برای ارسال درخواست های مختلف به سیستم شاپرک است.
        /// لطفاً برای اطلاعات بیشتر به گیت‌هاب پروژه یا مقاله من در ویرگول :
        /// https://virgool.io/@imun/pardakhtyari-nnnvvxpnyyay
        /// مراجعه کنید.
        /// </summary>
        /// <param name="model">مدل ورودی درخواست</param>
        /// <returns></returns>
        Task<ShaparakWriteResponse> WriteExternalRequestAsync(ShaparakWriteRequest model);

    }
}
