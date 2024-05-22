using ToDoList.DbContext;
using ToDoList.Model;
using ToDoList.ViewModel;

namespace ToDoList.View;

public partial class CreateToDo : ContentPage
{
	private Action<ToDoItem> _callback;
    private CreateToDoViewModel _createToDoViewModel;

    public CreateToDo(Action<ToDoItem> callback)
	{
        _callback = callback;
        Init();
    }

    public CreateToDo(ToDoItem toDoItem)
    {
        Init();
        _createToDoViewModel.InitEntryValues(toDoItem);
    }

    private void Init()
    {
        InitializeComponent();
        _createToDoViewModel = new CreateToDoViewModel(_callback);
        BindingContext = _createToDoViewModel;
    }
}