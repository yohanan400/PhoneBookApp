using PhoneBookApp.Services;
using PhoneBookApp.Stores;
using PhoneBookApp.ViewModels;
using System.Windows;

namespace PhoneBookApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ContactService _contactService;
    private readonly NavigationStore _navigationStore;

    public App()
    {
        _navigationStore = new NavigationStore();
        _contactService = new ContactService();
        //new MainWindow(_contactService).Show();
    }

    protected override void OnStartup(StartupEventArgs e)
    {

        _navigationStore.CurrentViewModel = CreateContactsListViewModel();

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_navigationStore)
        };
        MainWindow.Show();
        base.OnStartup(e);
    }

    private ContactsListViewModel CreateContactsListViewModel()
    {
        return new ContactsListViewModel(_contactService, new NavigationService(_navigationStore, CreateAddNewContactViewModel));
    }

    private AddNewContactViewModel CreateAddNewContactViewModel()
    {
        return new AddNewContactViewModel(_contactService, new NavigationService(_navigationStore, CreateContactsListViewModel));
    }

}

