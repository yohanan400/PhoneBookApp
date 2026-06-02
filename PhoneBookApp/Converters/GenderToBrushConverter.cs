using PhoneBookApp.Models;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using static PhoneBookApp.Models.Enums;

namespace PhoneBookApp.Converters
{
    public class GenderToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((ContactForListModel)value).Gender == Gender.Male) return Brushes.Aqua;
            else return Brushes.Pink;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
