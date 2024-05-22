using System.Globalization;

namespace ToDoList.Converter
{
    public class BoolToColorConverter : IValueConverter
    {
        //Bool
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool)value ? Colors.Green : Colors.Red;
        }

        //Color
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ((Color)value).Equals(Colors.Green);
        }
    }
}
