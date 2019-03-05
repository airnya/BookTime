using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using TextSix.Models;

namespace TextSix.Data
{
    public class BookItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public BookItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<BookItem>().Wait();
            database.CreateTableAsync<CategoryItem>().Wait();
        }

        public Task<List<BookItem>> GetItemsAsync()
        {
            return database.Table<BookItem>().ToListAsync();
        }

        public Task<List<BookItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<BookItem>("SELECT * FROM [BookItem] WHERE [Done] = 0");
        }

        public Task<BookItem> GetItemAsync(int id)
        {
            return database.Table<BookItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BookItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BookItem item)
        {
            return database.DeleteAsync(item);
        }

        //for Category

        public Task<List<CategoryItem>> GetCategoriesAsync()
        {
            return database.Table<CategoryItem>().ToListAsync();
        }

        public Task<List<CategoryItem>> GetCategoryNotDoneAsync()
        {
            return database.QueryAsync<CategoryItem>("SELECT * FROM [CategoryItem] WHERE [Done] = 0");
        }

        public Task<CategoryItem> GetCategoryAsync(int id)
        {
            return database.Table<CategoryItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveCategoryAsync(CategoryItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteCategoryAsync(CategoryItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}