using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBApp.Models;

namespace DBApp.Services
{
    public class ClientService
    {
        private readonly SQLiteAsyncConnection _database;

        public ClientService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Client>().Wait();
        }

     
        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

     
        public Task<int> SaveClientAsync(Client client)
        {
            return _database.InsertAsync(client);
        }

        public Task<int> UpdateClientAsync(Client client)
        {
            return _database.UpdateAsync(client);
        }

 
        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }
    }
}