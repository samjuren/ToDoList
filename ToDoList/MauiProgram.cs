using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;
using ToDoList.DbContext;

namespace ToDoList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            CreateDatabase();
            return BuildMauiApp();
        }

        private static void CreateDatabase()
        {
            DatabaseHandler.Init();
        }

        private static MauiApp BuildMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBottomSheet()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
