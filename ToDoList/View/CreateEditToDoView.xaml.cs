using ToDoList.DbContext;
using ToDoList.Helpers;
using ToDoList.Model;
using ToDoList.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList.View;

public partial class CreateEditToDoView : ContentPage
{
	private Action<ToDoItem> _callback;
    private CreateEditToDoViewModel _createToDoViewModel;

    public CreateEditToDoView(Action<ToDoItem> callback)
	{   
        _callback = callback;
        Init(false);
    }

    public CreateEditToDoView(ToDoItem toDoItem)
    {
        Init(true);
        _createToDoViewModel.InitEntryValues(toDoItem);
    }

    private void Init(bool isEdit)
    {
        InitializeComponent();
        _createToDoViewModel = new CreateEditToDoViewModel(_callback);
        BindingContext = _createToDoViewModel;

        if (isEdit) LblTitleScreen.Text = "Edição de Tarefas";        
        else LblTitleScreen.Text = "Criação de Tarefas";
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await NavigationHelper.PopModalAsync();
    }
}