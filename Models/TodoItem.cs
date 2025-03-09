
namespace TodoApp.Models;

using SQLite;


public class TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description {get; set;}

    public DateTime CreatedDate { get; set;} = DateTime.Now;

    public string Color {get; set;}

    public bool IsDone { get; set; }

}
