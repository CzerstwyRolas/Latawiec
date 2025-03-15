using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBApp.Models
{
    [Table("FavouriteFood")]
    public class FavouriteFood
    {
        [Column("id")]
        [AutoIncrement, PrimaryKey]
        public long id { get; set; }
        [Column("food")]
        public Food food { get; set; }
        [Column("client")]
        public Client client { get; set; }

    }
}
