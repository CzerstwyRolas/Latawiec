﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using DBApp.Models;
using DBApp.Services;
using System.Threading.Tasks;

namespace DBApp.ViewModels
{
    public class FavouriteFoodViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FavouriteFood> FavouriteFoods { get; set; }
        public ObservableCollection<Food> Foods { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ICommand AddFavouriteFoodCommand { get; set; }

        private Food _selectedFood;
        public Food SelectedFood
        {
            get => _selectedFood;
            set
            {
                _selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private readonly FavouriteFoodService _favouriteFoodService;
        private readonly FoodService _foodService;
        private readonly ClientService _clientService;

        public FavouriteFoodViewModel(string dbPath)
        {
            FavouriteFoods = new ObservableCollection<FavouriteFood>();
            Foods = new ObservableCollection<Food>();
            Clients = new ObservableCollection<Client>();
            AddFavouriteFoodCommand = new Command(async () => await AddFavouriteFood());

            _favouriteFoodService = new FavouriteFoodService(dbPath);
            _foodService = new FoodService(dbPath);
            _clientService = new ClientService(dbPath);

            LoadData();
        }

        private async void LoadData()
        {
            await LoadFoods();
            await LoadClients();
            await LoadFavouriteFoods();
        }

        private async Task LoadFoods()
        {
            var foods = await _foodService.GetFoodsAsync();
            Foods.Clear();
            foreach (var food in foods)
            {
                Foods.Add(food);
            }
        }

        private async Task LoadClients()
        {
            var clients = await _clientService.GetClientsAsync();
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }

        private async Task LoadFavouriteFoods()
        {
            var favouriteFoods = await _favouriteFoodService.GetFavouriteFoodsAsync();
            FavouriteFoods.Clear();
            foreach (var favouriteFood in favouriteFoods)
            {
                FavouriteFoods.Add(favouriteFood);
            }
        }

        private async Task AddFavouriteFood()
        {
            if (SelectedFood != null && SelectedClient != null)
            {
                var newFavouriteFood = new FavouriteFood { food = SelectedFood, client = SelectedClient };
                await _favouriteFoodService.SaveFavouriteFoodAsync(newFavouriteFood);
                FavouriteFoods.Add(newFavouriteFood);
                SelectedFood = null; // Reset selection
                SelectedClient = null; // Reset selection
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}