using Newtonsoft.Json;
using PhoneBookApp.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using PhoneBookApp.Services;
using PhoneBookApp.Views;
namespace PhoneBookApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}