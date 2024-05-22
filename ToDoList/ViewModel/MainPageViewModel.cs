using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.DbContext;
using ToDoList.Helpers;
using ToDoList.Model;
using ToDoList.View;

namespace ToDoList.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<ToDoItem> ToDoList { get; set; }
        public ICommand NavigateToAddViewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Color ColorSwitch { get; set; }

        public MainPageViewModel()
        {
            NavigateToAddViewCommand = new Command(NavigateToAddView);
            DeleteCommand = new Command(DeleteItem);
            ToDoList = new ObservableCollection<ToDoItem>();
            LoadItems();
        }

        private async void DeleteItem(object toDoItem)
        {

            ToDoItem item = (ToDoItem)toDoItem;
            ToDoList.Remove(item);
            DatabaseHandler.Delete(toDoItem);

        }

        private void LoadItems()
        {
            ToDoList.Clear();

            List<ToDoItem> items = DatabaseHandler.GetAll<ToDoItem>();

            foreach (ToDoItem item in items)
            {
                ToDoList.Add(item);
            }
        }

        private void NavigateToAddView()
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateToDo(Callback));
        }

        private void Callback(ToDoItem todoItem)
        {
            ToDoList.Add(todoItem);
        }
    }
}
