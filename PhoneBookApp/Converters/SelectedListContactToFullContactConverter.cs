using PhoneBookApp.Models;
using PhoneBookApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace PhoneBookApp.Converters
{
    public class SelectedListContactToFullContactConverter : IValueConverter
    {
        ContactService _contactService = new ContactService();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return _contactService.InitialNewContact();
            return _contactService.GetFullContactDetails(((ContactForListModel)value).Id);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _contactService.ConvertToContactToList((ContactModel)value);
        }
    }
}