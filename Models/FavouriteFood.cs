using DBApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBApp.Models
{
    public class FavouriteFood
    {
        [PrimaryKey, AutoIncrement]
        public long id { get; set; }
        public Food food { get; set; }
        public Client client { get; set; }
    }
}