using Asp_Dot_Net_Web_Api_Prac_Service.Extension;
using Microsoft.Extensions.Logging;

namespace Asp_Dot_Net_Maui_Prac_Client_Two
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddProductServiceExtension( options =>
                {
                    options.ApiUrl = "https://localhost:7230";
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
