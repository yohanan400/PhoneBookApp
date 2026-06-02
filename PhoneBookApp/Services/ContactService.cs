using Newtonsoft.Json;
using PhoneBookApp.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
using static PhoneBookApp.Models.Enums;

namespace PhoneBookApp.Services
{
    public class ContactService
    {
        private static int nextId;
        private ObservableCollection<ContactModel> _contacts;
        private string resourcesDirectory = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName, "resources");
        private string _contactsFilePath;

        public ContactService()
        {
            _contactsFilePath = Path.Combine(resourcesDirectory, "Contacts.json");
            LoadDataToList();
            nextId = _contacts[_contacts.Count() - 1].Id + 1;
        }

        public ObservableCollection<ContactModel> LoadDataToList()
        {
            try
            {
                if (!File.Exists(_contactsFilePath))
                {
                    MessageBox.Show($"File not found: {_contactsFilePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new Exception();
                }

                string contats = File.ReadAllText(_contactsFilePath);
                return _contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(contats)!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return new();
        }

        public bool AddNewContact(ContactModel newContact)
        {
            if (IsNotFull(newContact))
            {
                MessageBox.Show($"Some filds are empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                try
                {
                    
                    newContact.Id = nextId++;
                    _contacts.Add(newContact);
                    File.WriteAllText(_contactsFilePath, JsonConvert.SerializeObject(_contacts));

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
        }

        public ObservableCollection<ContactModel> GetContactsByString(string filter)
        {
            if (filter is null) return _contacts;
            return new ObservableCollection<ContactModel>( from contact in _contacts where contact.FirstName.Contains(filter) select contact);
        }

        public ContactModel InitialNewContact()
        {
            return new ContactModel
            {
                Id = 0,
                FirstName = "",
                LastName = "",
                PhoneNumber = "",
                Department = "",
                Email = "",
                Gender = Enums.Gender.Male,
                PicturePath = ""
            };
        }

        public string? OpenFile(string filters)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = ".png";
            fileDialog.Filter = filters;

            return fileDialog.ShowDialog() == true ? fileDialog.SafeFileName : null;
        }

        public string GetFullPath(string relativePath)
        {
            return Path.Combine(resourcesDirectory, relativePath);
        }

        public ContactModel GetFullContactDetails(int id)
        {
            
            return _contacts.FirstOrDefault(x => x.Id == id) ?? InitialNewContact();
        }

        public ContactForListModel ConvertToContactToList(ContactModel contact)
        {
            
            return contact is null? throw new NullReferenceException() : new ContactForListModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Gender = contact.Gender
            };
        }

        public bool DeleteContact(int id)
        {
            try
            {
                MessageBox.Show($"contact to delete: {_contacts.First(c => c.Id == id).ToString()}", "Info", MessageBoxButton.OK);
                if(_contacts.Remove(_contacts.First(c => c.Id == id)) == true)
                {
                    File.WriteAllText(_contactsFilePath, JsonConvert.SerializeObject(_contacts));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Someting went wrong. Try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        }

        private bool IsNotFull(ContactModel contactModel)
        {

            if (
                contactModel.FirstName == "" ||
        contactModel.LastName == "" ||
        contactModel.PhoneNumber == "" ||
        contactModel.Department == "" ||
        contactModel.Email == "" ||
        contactModel.Description == "") return true;
            else return false;
        }

    }
}
