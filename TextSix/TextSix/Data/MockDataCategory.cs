﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using TextSix.Models;

namespace TextSix.Data
{
    public class MockDataCategory : IDataStoreCategory<Category>
    {
        List<Category> categories;

        public MockDataCategory()
        {
            categories = new List<Category>();
            var mockItems = new List<Category>
            {
                new Category { Id = Guid.NewGuid().ToString(), IconSource="space.png", Text = "Первая категория", Description="Описание первой категории." },
                new Category { Id = Guid.NewGuid().ToString(), IconSource="rainbow.png", Text = "Вторая категория", Description="Описание второй категории." },
                new Category { Id = Guid.NewGuid().ToString(), IconSource="globe.png", Text = "Третья категория", Description="Описание третьей категории." },
            };

            foreach (var category in mockItems)
            {
                categories.Add(category);
            }
        }

        public async Task<bool> AddItemAsync(Category category)
        {
            categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Category category)
        {
            var oldItem = categories.Where((Category arg) => arg.Id == category.Id).FirstOrDefault();
            categories.Remove(oldItem);
            categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldCategory = categories.Where((Category arg) => arg.Id == id).FirstOrDefault();
            categories.Remove(oldCategory);

            return await Task.FromResult(true);
        }

        public async Task<Category> GetItemAsync(string id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categories);
        }
    }
}