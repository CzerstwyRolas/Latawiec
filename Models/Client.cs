using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBApp.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}