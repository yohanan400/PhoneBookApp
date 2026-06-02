using System.ComponentModel;
using static PhoneBookApp.Models.Enums;

namespace PhoneBookApp.Models
{
    public class ContactModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber{ get; set; }
        public string Department{ get; set; }
        public string Email{ get; set; }
        public string? Description{ get; set; }
        public Gender Gender{ get; set; }
        //public string? PicturePath { get; set; }

        private string picturePath;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string PicturePath
        {
            get { return picturePath; }
            set { picturePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public override string? ToString()
        {
            return $"Id: {Id}," +
                $" FirstName: {FirstName}," +
                $" LastName: {LastName}," +
                $" PhoneNumber: {PhoneNumber}," +
                $" Department: {Department}," +
                $" Email: {Email}," +
                $" Description: {Description}," +
                $" Gender: {Gender}";
        }
    }
}
