using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOGO.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int IDUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
