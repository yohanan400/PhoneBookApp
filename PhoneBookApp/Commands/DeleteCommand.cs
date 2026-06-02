using PhoneBookApp.Services;
using System.Windows;

namespace PhoneBookApp.Commands
{
    public class DeleteCommand : CommandBase
    {

        private readonly ContactService _contactService;

        public DeleteCommand(ContactService contactService)
        {
            _contactService = contactService;
        }

        public override void Execute(object? parameter)
        {
            if (_contactService.DeleteContact((int)parameter!) == true)
            {
                MessageBox.Show("Contact deleted successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}