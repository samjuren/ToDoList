namespace ToDoList.Helpers
{
    public class NavigationHelper
    {
        public static async Task<bool> DisplayMessage(string message)
        {
            return await Application
                .Current?
                .MainPage?
                .DisplayAlert("Atençao", message, "Ok", "Cancelar");
        }

        public static async Task DisplayAlert(string message)
        {
            await Application
                .Current?
                .MainPage?
                .DisplayAlert("Atençao", message, "Ok");
        }

        public static async Task PushAsync(Page page)
        {
            await Application
                .Current?
                .MainPage?
                .Navigation?
                .PushAsync(page);
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
