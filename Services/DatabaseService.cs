using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DBApp.Models;
using System;

namespace DBApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clients.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Client>().Wait();
        }

        public Task<int> AddClientAsync(Client client) => _database.InsertAsync(client);
        public Task<int> DeleteClientAsync(Client client) => _database.DeleteAsync(client);
        public Task<List<Client>> GetClientsAsync() => _database.Table<Client>().ToListAsync();
    }
}
