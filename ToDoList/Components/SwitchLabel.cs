using ToDoList.Converter;

namespace ToDoList.Components
{
    public class SwitchLabel : HorizontalStackLayout
    {
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(
            nameof(IsToggled),
            typeof(bool),
            typeof(SwitchLabel),
            false,
            propertyChanged: OnIsExpandedChanged
        );

        private static void OnIsExpandedChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var ctrl = (SwitchLabel)bindable;
            ctrl.Switch.IsToggled = (bool)newvalue;
        }

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        public Label Label { get; set; }
        public Switch Switch { get; set; }

        public SwitchLabel()
        {
            Label = new Label();
            Label.SetBinding(Label.TextColorProperty, "IsConcluded", BindingMode.TwoWay, converter: new BoolToColorConverter());

            Switch = new Switch();

            Add(Switch);
            Add(Label);

            Switch.Toggled += Switch_Toggled;

            Label.Text = "Não concluido";
            Label.TextColor = Colors.Red;
        }

        private void Switch_Toggled(object? sender, ToggledEventArgs e)
        {
            IsToggled = Switch.IsToggled;

            if (Switch.IsToggled)
            {
                Label.Text = "Concluido";
                Label.TextColor = Colors.Green;
            }
            else
            {
                Label.Text = "Não concluido";
                Label.TextColor = Colors.Red;
            }
        }
    }
}
