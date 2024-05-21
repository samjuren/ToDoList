using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.DbContext;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    public class CreateToDoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _textTitle { get; set; }
        private string _textDescription { get; set; }

        public string TextTitle
        {
            get => _textTitle;
            set
            {
                if (_textTitle != value)
                {
                    _textTitle = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TextDescription
        {
            get => _textDescription;
            set
            {
                if (_textDescription != value)
                {
                    _textDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        private Action<ToDoItem> _callback;
        public ICommand AddToDoCommand { get; set; }

        public CreateToDoViewModel(Action<ToDoItem> callback)
        {
            AddToDoCommand = new Command(() =>
            {
                AddToDo(callback);
            });
        }

        public void AddToDo(Action<ToDoItem> callback)
        {
            try
            {
                ToDoItem toDoItem = new ToDoItem();
                toDoItem.Title = TextTitle;
                toDoItem.Description = TextDescription;

                DatabaseHandler.Insert(toDoItem);

                _callback = callback;
                _callback?.Invoke(toDoItem);

                App.Current.MainPage.DisplayAlert("Sucesso", "Tarefa cadastrada", "Ok");
            }
            catch (Exception ex) 
            {
                App.Current.MainPage.DisplayAlert("Erro", "Ocorreu um erro", "Ok");
            }

        }
    }
}
