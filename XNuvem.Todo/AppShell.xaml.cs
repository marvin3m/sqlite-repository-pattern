using XNuvem.Todo.Views;

namespace XNuvem.Todo
{
    public partial class AppShell : Shell
    {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoItemPage), typeof(TodoItemPage));
        }
    }
}