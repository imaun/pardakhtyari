using System;
using Shaparak.PaymentFacilitation;
using Shaparak.PaymentFacilitation.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection {

    public static class ShaparakBuilderExtension {

        /// <summary>
        /// Adds Payment Facilitaion or (Pardakhtyari پرداخت‌یاری) services to your Application.
        /// for more informations about how to work with ShaparakClient pls visit :
        /// https://virgool.io/@imun/pardakhtyari-nnnvvxpnyyay
        /// or contact me at : hi@imaun.ir
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configure">Options</param>
        /// <returns></returns>
        public static IServiceCollection AddPaymentFacilitation(
            this IServiceCollection services,
            Action<ShaparakOptions> configure) {
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            services.AddHttpClient();
            services.AddSingleton<IHttpRestClient, HttpRestClient>();
            services.Configure(configure);
            services.AddScoped<IShaparakClient, ShaparakClient>();

            return services;
        }


    }
}
