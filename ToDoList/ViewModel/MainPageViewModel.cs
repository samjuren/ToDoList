using System.Collections.ObjectModel;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    public class MainPageViewModel
    {
        public ObservableCollection<ToDoItem> ToDoList { get; set; }
        public MainPageViewModel()
        {
            CriarToDo();
        }

        private void CriarToDo()
        {
            ToDoList = new ObservableCollection<ToDoItem>
            {
                new ToDoItem
                {
                    Id = 1,
                    Title = "Teste Samuel",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
                new ToDoItem
                {
                    Id = 2,
                    Title = "Teste Samuel 2",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
                new ToDoItem
                {
                    Id = 3,
                    Title = "Teste Samuel 3",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
                new ToDoItem
                {
                    Id = 4,
                    Title = "Teste Samuel 4",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
                new ToDoItem
                {
                    Id = 5,
                    Title = "Teste Samuel 5",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
                new ToDoItem
                {
                    Id = 6,
                    Title = "Teste Samuel 6",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
                new ToDoItem
                {
                    Id = 7,
                    Title = "Teste Samuel 7",
                    Description = "Ir ao mercado",
                    Status = 1,
                },
            };
        }
    }
}
