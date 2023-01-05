using System.Collections.ObjectModel;
using XNuvem.Mobile.Data;
using XNuvem.Todo.Models;

namespace XNuvem.Todo.Views;

public partial class TodoListPage : ContentPage
{
    IRepository<TodoItem> repository;
    public ObservableCollection<TodoItem> Items { get; set; } = new();
    public TodoListPage(IRepository<TodoItem> todoRepository)
	{
		InitializeComponent();
        repository = todoRepository;
        BindingContext = this;
    }


    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await repository.Table.ToListAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);

        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new TodoItem()
        });
    }

    private async void  CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not TodoItem item)
            return;

        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}

