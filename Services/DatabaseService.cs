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
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBApp.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Client>().Wait();
            _database.CreateTableAsync<Food>().Wait();
            _database.CreateTableAsync<FavouriteFood>().Wait();
        }

        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<int> AddClientAsync(Client client)
        {
            return _database.InsertAsync(client);
        }

        public Task<int> AddFoodAsync(Food food)
        {
            return _database.InsertAsync(food);
        }

        public Task<int> AddFavouriteFoodAsync(FavouriteFood favouriteFood)
        {
            return _database.InsertAsync(favouriteFood);
        }
        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }
    }
}
