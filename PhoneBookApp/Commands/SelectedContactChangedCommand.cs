using PhoneBookApp.Models;
using PhoneBookApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBookApp.Commands
{
    public class SelectedContactChangedCommand(Action<ContactForListModel> execute) : CommandBase
    {

        private readonly ContactsListViewModel _contactsListViewModel;
        private readonly ContactModel _selectedContact;
        private readonly Action<ContactForListModel> _execute = execute;

        public override void Execute(object? parameter)
        {
            if (parameter is not null) _execute((ContactForListModel)parameter);
            else  MessageBox.Show("No details to show!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}