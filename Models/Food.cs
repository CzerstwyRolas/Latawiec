using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public enum FoodType
    {
        Vegetable, Fruit, Seafood, Meat
    }
    class Food
    {
        [PrimaryKey, AutoIncrement]
        long id { get; set; }
        string name { get; set; }
        int in_stock { get; set; }
        FoodType type { get; set; }
    }
}
