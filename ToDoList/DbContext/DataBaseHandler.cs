using SQLite;
using ToDoList.Model;

namespace ToDoList.DbContext
{
    public class DataBaseHandler
    {
        public static SQLiteConnection? Connection { get; set; }

        public static void Init()
        {
            CreateConnection();
            CreateTable();
        }

        private static void CreateConnection()
        {
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDo_Entrevista.db");
            Connection = new SQLiteConnection(new SQLiteConnectionString(databasePath));
        }

        private static void CreateTable()
        {
            Connection?.CreateTable(typeof(ToDoItem));
        }

        //Metedos de CRUP db

        public static void Insert(object obj)
        {
            Connection?.Insert(obj);
        }

        public static void Delete(object obj)
        {
            Connection?.Delete(obj);
        }

        public static void Update(object obj)
        {
            Connection?.Update(obj);
        }

        public static List<T> GetAll<T>() where T : new()
        {
            return Connection.Table<T>().ToList();
        }
    }
}
