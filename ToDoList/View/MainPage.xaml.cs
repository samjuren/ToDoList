﻿using ToDoList.DbContext;
using ToDoList.Helpers;
using ToDoList.Model;
using ToDoList.View;
using ToDoList.ViewModel;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
            _mainPageViewModel = new MainPageViewModel();
            BindingContext = _mainPageViewModel;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton image = (ImageButton)sender;
            ToDoItem model = (ToDoItem)image.BindingContext;

            string option = await DisplayActionSheet("", "Cancelar", "", "Editar", "Deletar");

            switch (option)
            {
                case "Editar":
                    await NavigationHelper.PushModalAsync(new CreateEditToDoView(model));
                    break;
                case "Deletar":
                    await DeleteItem(model);
                    break;
            }
        }

        private async Task DeleteItem(ToDoItem model)
        {
            bool resp = await DisplayAlert("Atenção", "Deseja deletar esse item?", "Sim", "Não");

            if (resp)
            {
                _mainPageViewModel.DeleteCommand.Execute(model);
            }
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            ToDoItem model = (ToDoItem)checkBox.BindingContext;
            model.Status = checkBox.IsChecked ? "Concluído" : "Não Concluído";
            _mainPageViewModel.UpdateCommand.Execute(model);
        }
    }
}