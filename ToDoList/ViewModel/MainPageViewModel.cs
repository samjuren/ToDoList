using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
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
        public ICommand UpdateCommand { get; set; }
        public Color ColorSwitch { get; set; }

        private string _labelColletionEmpty {  get; set; }
        public string labelColletionEmpty 
        {
            get =>  _labelColletionEmpty;
            set
            {
                _labelColletionEmpty = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            NavigateToAddViewCommand = new Command(NavigateToAddView);
            DeleteCommand = new Command(DeleteItem);
            UpdateCommand = new Command(Update);
            ToDoList = new ObservableCollection<ToDoItem>();
            LoadItems();
        }

        private void Update(object item)
        {
            ToDoItem toDoItem = (ToDoItem)item;
            DatabaseHandler.Update(toDoItem);
        }

        private async void DeleteItem(object toDoItem)
        {
            ToDoItem item = (ToDoItem)toDoItem;
            ToDoList.Remove(item);
            DatabaseHandler.Delete(toDoItem);

            if (ToDoList.Count == 0)
                labelColletionEmpty = "Lista vazia";
        }

        private void LoadItems()
        {
            ToDoList.Clear();

            List<ToDoItem> items = DatabaseHandler.GetAll<ToDoItem>();

            if (items.Count == 0)
                labelColletionEmpty = "Lista vazia";

            foreach (ToDoItem item in items)
            {
                ToDoList.Add(item);
            }
        }

        private async void NavigateToAddView()
        {
            await NavigationHelper.PushModalAsync(new CreateEditToDoView(Callback));
        }

        private void Callback(ToDoItem todoItem)
        {
            ToDoList.Add(todoItem);
            labelColletionEmpty = string.Empty;
        }
    }
}
