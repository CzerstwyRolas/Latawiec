using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBApp.Models
{
    [Table("Client")]
    public class Client
    {
        [Column("id")]
        [PrimaryKey, AutoIncrement]
        private long id { set; get; }
        [Column("name")]
        public string name { set; get; }
        [Column("surname")]
        public string surname { set; get; }
    }
}
