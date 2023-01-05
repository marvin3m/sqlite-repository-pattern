# MAUI SQLite Repository Pattern implementation

## Dependencies:

| Version | Package | Description |
| ------- | ------- | ----------- |
| [![NuGet Package](https://img.shields.io/nuget/v/sqlite-net-pcl.svg)](https://www.nuget.org/packages/sqlite-net-pcl) | [sqlite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl) | .NET Standard Library |

## Database configuration:

Utilize the UseXNuvemDatabase to configure information of the SQLite database like the example below:

```csharp
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
            builder.Services.AddSingleton<TodoListPage>();
            builder.Services.AddTransient<TodoItemPage>();
            return builder.Build();
        }
    }
```

You can add as many tables as you like on settings.Tables.Add<T>() option.

The full configuration options on settings is:

```csharp
public interface IDatabaseSettings 
{
        string FilePath { get; set; }
        string FileName { get; set; }
        SQLiteOpenFlags Flags { get; set; }
        IList<Type> Tables { get; set; }
}
```


## Usage:
  
  To use your repository you need to add your page/view on the service list:
  
```csharp
  builder.Services.AddSingleton<TodoListPage>();
  builder.Services.AddTransient<TodoItemPage>();
```
  
  Now you can use your repository on your class like:
```csharp
public partial class TodoListPage : ContentPage
{
    IRepository<TodoItem> repository;
    public TodoItemPage(IRepository<TodoItem> todoRepository)
    {
        InitializeComponent();
        repository = todoRepository;
    }
  
    async Task<IList<TodoItem>> GetAll()
    {
        var items = await repository.Table.ToListAsync();
        return items;
    }
  
    async Task<TodoItem> GetById(int id) {
        var item = await repository.Table.Where(p => p.ID == id).FirstOrDefaultAsync();
        return item;
    }
    #region The rest of the class...
}
```
  
