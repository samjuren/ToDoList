using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using ToDoList.DbContext;
using ToDoList.Model;
using ToDoList.View;

namespace ToDoList.ViewModel
{
    public class MainPageViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public ObservableCollection<ToDoItem> ToDoList { get; set; }

        public ICommand NavigateToAddViewCommand { get; set; }

        public MainPageViewModel()
        {
            NavigateToAddViewCommand = new Command(NavigateToAddView);
            ToDoList = new ObservableCollection<ToDoItem>();
            LoadItems();
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
            LoadItems();
        }
    }
}
