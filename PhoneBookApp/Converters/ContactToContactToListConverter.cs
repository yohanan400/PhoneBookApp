using PhoneBookApp.Models;
using PhoneBookApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhoneBookApp.Converters
{
    public class ContactToContactToListConverter : IValueConverter
    {
        ContactService _contactService = new ContactService();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not null) return _contactService.ConvertToContactToList((ContactModel)value);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
