using Microsoft.Extensions.Logging;
using surveyintento2.Data;
using surveyintento2.View;

namespace surveyintento2
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<PartesqlDetailsPage>();
            builder.Services.AddTransient<partesqlPage>();

            builder.Services.AddSingleton<Database>();

            return builder.Build();

        }
    }
}