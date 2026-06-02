using PhoneBookApp.Commands;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhoneBookApp.ViewModels
{
    public class ContactsListViewModel : ViewModelBase
    {
        private readonly ContactService _contactService;

        private ObservableCollection<ContactModel> _fullContactsList;

        private ObservableCollection<ContactForListModel>? _contactsForList;

        public ObservableCollection<ContactForListModel>? ContactsForList
        {
            get { return _contactsForList; }
            set
            {
                _contactsForList = value;
                OnPropertyChanged(nameof(ContactsForList));
            }
        }

        private ContactModel? _selectedContact;

        public ContactModel? SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public ICommand SelectionChanged { get; }
        public ICommand AddContactCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshContactsListCommand { get; }
        public ICommand FilterCommand { get; }

        public ContactsListViewModel(ContactService contactService, NavigationService addContactNavigationService)
        {
            _contactService = contactService;
            _fullContactsList = _contactService.LoadDataToList();
            RefreshContactsList();

            if (_fullContactsList is not null) SelectedContact = _fullContactsList[0];

            SelectionChanged = new SelectedContactChangedCommand(ChangeSelectedContact);
            AddContactCommand = new NavigationCommand(addContactNavigationService);
            DeleteCommand = new DeleteCommand(_contactService);
            RefreshContactsListCommand = new RefreshContactsListCommand(RefreshContactsList);
            FilterCommand = new FilterCommand(GetContactsByString);
        }

        private void ChangeSelectedContact(ContactForListModel newSelectedContact)
        {
            SelectedContact = _contactService.GetFullContactDetails(newSelectedContact.Id);
        }

        private void RefreshContactsList()
        {
            if (_fullContactsList is not null && _fullContactsList.Count > 0) SelectedContact = _fullContactsList[0];
            else SelectedContact = null;

            if (_fullContactsList is not null) ContactsForList = [.. _fullContactsList.Select(c => new ContactForListModel
            {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
             Gender = c.Gender
             })];
        }

        private void GetContactsByString(string filter)
        {
            ContactsForList = [.. _contactService.GetContactsByString(filter).Select(c => new ContactForListModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Gender = c.Gender
            })]; ;
        }
    }
}
