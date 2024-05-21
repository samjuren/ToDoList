using ToDoList.DbContext;
using ToDoList.Model;
using ToDoList.ViewModel;

namespace ToDoList.View;

public partial class CreateToDo : ContentPage
{
	private Action<ToDoItem> _callback;

    public CreateToDo(Action<ToDoItem> callback)
	{
        _callback = callback;	
        InitializeComponent();
        BindingContext = new CreateToDoViewModel(callback);
    }
}