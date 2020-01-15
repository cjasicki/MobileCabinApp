using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Cabin_App.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID1 { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
