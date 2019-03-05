using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextSix.Models
{
    public class BookItem
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

    }
}
/*
        public int ID { get; set; }
        [ForeignKey(typeof(CategoryItem))]  // Specify the foreign key
        public string CategoryItemID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

        [ManyToOne]      // Many to one relationship with Stock
        public CategoryItem CategoryItem { get; set; }
 */
