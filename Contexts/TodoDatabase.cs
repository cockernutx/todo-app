using SQLite;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Contexts;
public class TodoDatabase
{
    SQLiteAsyncConnection Database;

    public TodoDatabase()
    {
        
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        Database.CreateTableAsync<TodoItem>().Wait();
    }

    public async Task<List<TodoItem>> GetItemsAsync() =>
        await Database.Table<TodoItem>().ToListAsync();

    public async Task<int> SaveItemAsync(TodoItem item)
    {
        if (item.Id != 0)
            return await Database.UpdateAsync(item);
        else
            return await Database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(TodoItem item) =>
        await Database.DeleteAsync(item);
}