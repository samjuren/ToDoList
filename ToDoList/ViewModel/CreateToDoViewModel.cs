using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.DbContext;
using ToDoList.Helpers;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    public class CreateToDoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ToDoItem EditToDoItem { get; set; }
        private string _textTitle { get; set; }
        private string _textDescription { get; set; }
        private bool _isConcluded { get; set; }

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

        public bool IsConcluded
        {
            get => _isConcluded;
            set
            {
                if (_isConcluded != value)
                {
                    _isConcluded = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddToDoCommand { get; set; }
        public ICommand PutToDoCommand { get; set; }


        public CreateToDoViewModel(Action<ToDoItem> callback)
        {
            AddToDoCommand = new Command(() => AddToDo(callback));
        }

        public async void AddToDo(Action<ToDoItem> callback)
        {
            try
            {
                AddToItem(callback);
                await NavigationHelper.PopModalAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await NavigationHelper.DisplayAlert("Ocorreu um erro");
            }
        }

        public async void AddToItem(Action<ToDoItem> callback)
        {
            if (EditToDoItem != null)
            {
                EditToDoItem.Title = TextTitle;
                EditToDoItem.Description = TextDescription;
                EditToDoItem.IsConcluded = IsConcluded;
                EditToDoItem.Status = IsConcluded ? "Concluído" : "Não Concluído";
                DatabaseHandler.Update(EditToDoItem);
                await NavigationHelper.DisplayAlert("Tarefa Atualizada");
                return;
            }

            ToDoItem toDoItem = new()
            {
                Title = TextTitle,
                Description = TextDescription,
                IsConcluded = IsConcluded,
                Status = IsConcluded ? "Concluído" : "Não Concluído"
            };

            DatabaseHandler.Insert(toDoItem);
            callback?.Invoke(toDoItem);
            await NavigationHelper.DisplayAlert("Tarefa cadastrada");
        }
        public void InitEntryValues(ToDoItem toDoItem)
        {
            EditToDoItem = toDoItem;

            TextTitle = toDoItem.Title;
            TextDescription = toDoItem.Description;
            IsConcluded = toDoItem.IsConcluded;
        }
    }
}
