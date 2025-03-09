using TodoApp.Models;
using TodoApp.Data;
using TodoApp.Contexts;

namespace TodoApp;

public partial class TodoItemPage : ContentPage
{
    TodoItem todoItem;

    public TodoItemPage(TodoItem item = null)
    {
        InitializeComponent();
        todoItem = item ?? new TodoItem();
        nameEntry.Text = todoItem.Name;
        doneSwitch.IsToggled = todoItem.IsDone;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        todoItem.Name = nameEntry.Text;
        todoItem.IsDone = doneSwitch.IsToggled;
        var db = new TodoDatabase();
        await db.SaveItemAsync(todoItem);
        await Navigation.PopAsync();
    }
}
