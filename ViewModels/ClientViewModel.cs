using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DBApp.Models;
using DBApp.Services;
using Xamarin.Forms;

namespace DBApp.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<Client> Clients { get; set; }

        public ICommand AddClientCommand { get; }

        public ClientViewModel()
        {
            _databaseService = new DatabaseService();
            Clients = new ObservableCollection<Client>();
            AddClientCommand = new Command(async () => await AddClient());

            LoadClients();
        }

        private async void LoadClients()
        {
            var clients = await _databaseService.GetClientsAsync();
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }

        public async Task AddClient()
        {
            var newClient = new Client { Name = "", Surname = "" };
            await _databaseService.AddClientAsync(newClient);
            Clients.Add(newClient);
        }
        public async Task DeleteClient()
        {
            var newClient = new Client { Name = "", Surname = "" };
            await _databaseService.DeleteClientAsync(newClient);
        }
    }
}
