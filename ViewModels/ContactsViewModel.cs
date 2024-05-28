using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Listas.Models;
using Listas.Services;

namespace Listas.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private readonly ContactService _contactService;
        public ObservableCollection<Models.Contact> Contacts { get; private set; } // Especificar el espacio de nombres completo
        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }

        public ContactsViewModel()
        {
            _contactService = new ContactService();
            Contacts = new ObservableCollection<Models.Contact>(); // Especificar el espacio de nombres completo
            RefreshCommand = new Command(async () => await LoadContacts());
            DeleteCommand = new Command<Models.Contact>(DeleteContact); // Especificar el espacio de nombres completo
            LoadContacts().ConfigureAwait(false);
        }

        private async Task LoadContacts()
        {
            var contacts = await _contactService.GetContactsAsync();
            Contacts.Clear();
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }

        private void DeleteContact(Models.Contact contact) // Especificar el espacio de nombres completo
        {
            if (contact != null)
            {
                Contacts.Remove(contact);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
