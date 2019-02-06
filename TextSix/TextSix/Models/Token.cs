using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextSix.Models
{
    public class Token
    {
        [PrimaryKey]
        public int Id { get; set; } 
        public string access_token { get; set; }
        public string erorr_description { get; set; }
        public DateTime expire_date { get; set; }

        public Token() { }
    }
}
