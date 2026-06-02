using PhoneBookApp.Commands;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhoneBookApp.ViewModels
{
    public class AddNewContactViewModel : ViewModelBase
    {

        private readonly ContactService _contactService;

        private ContactModel _newContact;

        public ContactModel NewContact
        {
            get { return _newContact; }
            set { 
                _newContact = value;
                OnPropertyChanged(nameof(NewContact));
            }
        }

        public ICommand ShowFileDialogCommand { get; }
        public ICommand AddNewContactCommand { get; }
        public ICommand ReturnToListCommand { get; }

        public AddNewContactViewModel(ContactService contactService, NavigationService navigationService)
        {
            _contactService = contactService;
            NewContact = _contactService.InitialNewContact();
            ShowFileDialogCommand = new ShowFileDialogCommand(_contactService, path => NewContact.PicturePath = path);
            AddNewContactCommand = new AddNewContactCommand(contactService, navigationService);
            ReturnToListCommand = new NavigationCommand(navigationService);
        }
    }
}
