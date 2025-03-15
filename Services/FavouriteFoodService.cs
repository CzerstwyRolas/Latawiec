using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBApp.Models;

namespace DBApp.Services
{
    public class FavouriteFoodService
    {
        private readonly SQLiteAsyncConnection _database;

        public FavouriteFoodService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FavouriteFood>().Wait();
        }

        // Get all favourite foods
        public Task<List<FavouriteFood>> GetFavouriteFoodsAsync()
        {
            return _database.Table<FavouriteFood>().ToListAsync();
        }

        // Add a new favourite food
        public Task<int> SaveFavouriteFoodAsync(FavouriteFood favouriteFood)
        {
            return _database.InsertAsync(favouriteFood);
        }

        // Update an existing favourite food
        public Task<int> UpdateFavouriteFoodAsync(FavouriteFood favouriteFood)
        {
            return _database.UpdateAsync(favouriteFood);
        }

        // Delete a favourite food
        public Task<int> DeleteFavouriteFoodAsync(FavouriteFood favouriteFood)
        {
            return _database.DeleteAsync(favouriteFood);
        }
    }
}