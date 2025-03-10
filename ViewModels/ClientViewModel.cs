using DBApp.Models;
using DBApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DBApp.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private string _name;
        private string _surname;
        private Client _currentClient;

        public ObservableCollection<Client> clients { get; set; } = new ObservableCollection<Client>();

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Surname
        {
            get => _surname;
            set { _surname = value; OnPropertyChanged(); }
        }

        public Client CurrentClient
        {
            get => _currentClient;
            set { _currentClient = value; OnPropertyChanged(); }
        }

        public ClientViewModel()
        {
            _databaseService = new DatabaseService();
            LoadClients();
        }

        public async void AddClient()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname))
            {
                var newClient = new Client { Name = Name, Surname = Surname };
                await _databaseService.AddClientAsync(newClient);
                Name = Surname = string.Empty;
                LoadClients();
            }
        }

        public async void DeleteClient()
        {
            if (CurrentClient != null)
            {
                await _databaseService.DeleteClientAsync(CurrentClient);
                CurrentClient = null;
                LoadClients();
            }
        }

        public async void LoadClients()
        {
            var clientsList = await _databaseService.GetClientsAsync();
            clients.Clear();
            foreach (var client in clientsList)
            {
                clients.Add(client);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
