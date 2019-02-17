using System;
using System.Collections.Generic;
using System.Text;
using TextSix.Models;

namespace TextSix.ViewModels
{
    public class ItemDetailCategoryView : BaseViewCategory
    {
        public Category Category { get; set; }
        public ItemDetailCategoryView(Category category = null)
        {
            Title = category?.Text;
            Category = category;
        }
    }
}

