using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using TextSix.Views;
using Xamarin.Forms;

namespace TextSix.ViewModels
{
    class CategoriesViewModel : BaseViewCategory
    {
        public ObservableCollection<Category> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public CategoriesViewModel()
        {
            Title = "КАТЕГОРИИ КНИГ";
            Categories = new ObservableCollection<Category>();
            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());

            MessagingCenter.Subscribe<NewCategoryPage, Category>(this, "AddItem", async (obj, category) =>
                {
                    var newItem = category as Category;
                    Categories.Add(newItem);
                    await DataStore.AddItemAsync(newItem);
                }
            );
        }

        async Task ExecuteLoadCategoriesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Categories.Clear();
                var categories = await DataStore.GetItemsAsync(true);
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
