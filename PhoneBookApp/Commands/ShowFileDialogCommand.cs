using PhoneBookApp.Services;
using PhoneBookApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBookApp.Commands
{
    public class ShowFileDialogCommand : CommandBase
    {

        private readonly ContactService _contactService;
        private readonly Action<string> _setPathAction;

        public ShowFileDialogCommand(ContactService contactService, Action<string> setPathAction)
        {
            _contactService = contactService;
            _setPathAction = setPathAction;
        }

        public override void Execute(object? parameter)
        {
            string filters = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            string? result = _contactService.OpenFile(filters);
            string fullResultPath = _contactService.GetFullPath(result);
            //if (File.Exists(result))
            if (File.Exists(fullResultPath))
            {
                _setPathAction?.Invoke(fullResultPath);
            }
            else
            {
                MessageBox.Show("File Not Exist!", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
