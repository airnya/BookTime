using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.ViewModels;
using TextSix.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailPage : ContentPage
    {
        ItemDetailCategoryView viewModel;

        public CategoryDetailPage(ItemDetailCategoryView viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CategoryDetailPage()
        {
            InitializeComponent();

            var category = new Category
            {
                Text = "Category 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailCategoryView(category);
            BindingContext = viewModel;
        }
    }
}