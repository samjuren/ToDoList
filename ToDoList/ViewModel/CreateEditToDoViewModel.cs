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
    public class CreateEditToDoViewModel : INotifyPropertyChanged
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
        private string _lblTitleScreen { get; set; }

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

        public string LblTitleScreen
        {
            get => _lblTitleScreen;
            set
            {
                if (_lblTitleScreen != value)
                {
                    _lblTitleScreen = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddToDoCommandItem { get; set; }

        public CreateEditToDoViewModel(Action<ToDoItem> callback)
        {
            AddToDoCommandItem = new Command(() => AddToDo(callback));
        }

        public void AddToDo(Action<ToDoItem> callback)
        {
            CreateOrUpdateItem(callback);
        }

        public async void CreateOrUpdateItem(Action<ToDoItem> callback)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TextTitle) &&
                    !string.IsNullOrWhiteSpace(TextDescription))
                {
                    if (EditToDoItem != null)
                    {
                        await UpdateTodoItem();
                        return;
                    }


                    InsertTodoItem(callback);
                    await NavigationHelper.DisplayAlert("Tarefa cadastrada");
                    await NavigationHelper.PopModalAsync();
                    return;
                }

                await NavigationHelper.DisplayAlert("Favor preencher os campos acima");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await NavigationHelper.DisplayAlert("Ocorreu um erro");
            }
        }

        private void InsertTodoItem(Action<ToDoItem> callback)
        {
            ToDoItem toDoItem = new()
            {
                Title = TextTitle,
                Description = TextDescription,
                IsConcluded = IsConcluded,
                Status = IsConcluded ? "Concluído" : "Não Concluído"
            };

            DatabaseHandler.Insert(toDoItem);
            callback?.Invoke(toDoItem);

        }

        private async Task UpdateTodoItem()
        {
            EditToDoItem.Title = TextTitle;
            EditToDoItem.Description = TextDescription;
            EditToDoItem.IsConcluded = IsConcluded;
            EditToDoItem.Status = IsConcluded ? "Concluído" : "Não Concluído";

            DatabaseHandler.Update(EditToDoItem);
            await NavigationHelper.PopModalAsync();
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
