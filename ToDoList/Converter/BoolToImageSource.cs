using System.Globalization;

namespace ToDoList.Converter
{
    public class BoolToImageSource : IValueConverter
    {
        string iconDone = "icon_done50.png";
        string iconNotDone = "icon_not_done50.png";

        //Bool
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool)value ? iconDone : iconNotDone;
        }

        //Color
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ((FileImageSource)value).File == iconDone;
        }
    }
}
