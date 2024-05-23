namespace ToDoList.Helpers
{
    public class NavigationHelper
    {
        public static async Task<bool> DisplayMessage(string message)
        {
            return await Application
                .Current?
                .MainPage?
                .DisplayAlert("Atenção", message, "Ok", "Cancelar");
        }

        public static async Task DisplayAlert(string message)
        {
            await Application
                .Current?
                .MainPage?
                .DisplayAlert("Atenção", message, "Ok");
        }

        public static async Task PushModalAsync(Page page)
        {
            await Application
                .Current?
                .MainPage?
                .Navigation?
                .PushModalAsync(page);
        }

        public static async Task PopAsync()
        {
            await Application
               .Current?
               .MainPage?
               .Navigation?
               .PopAsync();
        }

        public static async Task PopModalAsync()
        {
            await Application
               .Current?
               .MainPage?
               .Navigation?
               .PopModalAsync();
        }
    }
}
