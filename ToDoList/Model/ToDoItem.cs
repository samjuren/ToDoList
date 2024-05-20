using SQLite;

namespace ToDoList.Model
{
    [Table("CREATE_LOGIN")]
    public class ToDoItem
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }

    }
}
