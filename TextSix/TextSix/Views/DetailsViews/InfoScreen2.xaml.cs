using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TextSix.Models;

namespace TextSix.Views.DetailsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScreen2 : ContentPage
    {
        CategoriesViewModel viewModel;

        public InfoScreen2()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Category;
            if (item == null)
                return;

            await Navigation.PushAsync(new CategoryDetailPage(new ItemDetailCategoryView(item)));

            // Manually deselect item.
            CategoriesListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewCategoryPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categories.Count == 0)
                viewModel.LoadCategoriesCommand.Execute(null);
        }
    }
}
