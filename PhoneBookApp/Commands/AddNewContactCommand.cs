using PhoneBookApp.Models;
using PhoneBookApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhoneBookApp.Commands
{
    public class AddNewContactCommand : CommandBase
    {
        private readonly ContactService _contactService;
        private readonly NavigationService _navigationService;

        public AddNewContactCommand(ContactService contactService, NavigationService navigationService)
        {
            _contactService = contactService;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is null || !_contactService.AddNewContact((ContactModel)parameter))
            {
                MessageBox.Show("Can't save new contact. Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _navigationService.Navigate();
            }
        }
    }
}
