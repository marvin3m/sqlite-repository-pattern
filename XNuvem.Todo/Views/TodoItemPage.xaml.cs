using XNuvem.Mobile.Data;
using XNuvem.Todo.Models;

namespace XNuvem.Todo.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
	TodoItem item;
	public TodoItem Item
	{
		get => BindingContext as TodoItem;
		set => BindingContext = value;
	}
    IRepository<TodoItem> repository;
    public TodoItemPage(IRepository<TodoItem> todoRepository)
    {
        InitializeComponent();
        repository = todoRepository;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }

        await repository.SaveAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await repository.DeleteAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}