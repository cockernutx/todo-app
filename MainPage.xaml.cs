using System.Collections.ObjectModel;
using TodoApp.Models;
using TodoApp.Data;
using TodoApp.Contexts;

namespace TodoApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<TodoItem> TodoItems { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var db = new TodoDatabase();
        var items = await db.GetItemsAsync();
        TodoItems.Clear();
        foreach (var item in items)
        {
            TodoItems.Add(item);
        }
    }

    async void OnAddTodoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TodoItemPage());
    }

    async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;
            
        var item = e.SelectedItem as TodoItem;
        await Navigation.PushAsync(new TodoItemPage(item));
        // Deselect item.
        ((ListView)sender).SelectedItem = null;
    }
}
