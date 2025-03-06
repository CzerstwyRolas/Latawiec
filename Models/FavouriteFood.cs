using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class FavouriteFood
    {
        [PrimaryKey, AutoIncrement]
        public long id { get; set; }
        public Food food { get; set; }
        public Client client { get; set; }
    }
}
