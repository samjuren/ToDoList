using SQLite;

namespace ToDoList.Model
{
    [Table("ToDoList")]
    public class ToDoItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }

    }
}
