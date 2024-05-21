using ToDoList.DbContext;
using ToDoList.Model;

namespace ToDoList.View;

public partial class CreateToDo : ContentPage
{
	private Action<ToDoItem> _callback;

    public CreateToDo(Action<ToDoItem> callback)
	{
        _callback = callback;	
        InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		ToDoItem toDoItem = new ToDoItem();
		toDoItem.Title = entryTitle.Text;
		toDoItem.Description = entryDescription.Text;
		DatabaseHandler.Insert(toDoItem);

        _callback?.Invoke(toDoItem);
    }
}