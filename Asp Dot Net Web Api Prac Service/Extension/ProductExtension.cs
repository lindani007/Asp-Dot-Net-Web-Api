using Asp_Dot_Net_Web_Api_Prac_Service.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp_Dot_Net_Web_Api_Prac_Service.Extension
{
    public static class ProductExtension
    {
        public static void AddProductServiceExtension(this IServiceCollection services, Action<ApiBaseUrl> configure)
        {
            services.Configure(configure);
            services.AddSingleton(provider =>
            {
                var apiBaseUrl = provider.GetRequiredService<Microsoft.Extensions.Options.IOptions<ApiBaseUrl>>().Value;
                return new ProductService(apiBaseUrl);
            });
        }
    }
}
