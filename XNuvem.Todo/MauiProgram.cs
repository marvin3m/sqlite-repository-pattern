using Microsoft.Extensions.Logging;
using XNuvem.Todo.Models;
using XNuvem.Mobile.Data;
using XNuvem.Todo.Views;

namespace XNuvem.Todo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseXNuvemDatabase(settings => {
                    settings.FileName = "XNuvemTodoSQLite.db3";
                    settings.Tables.Add<TodoItem>();
                }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<TodoListPage>();
            builder.Services.AddTransient<TodoItemPage>();
            return builder.Build();
        }
    }
}