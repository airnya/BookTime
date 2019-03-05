using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedCategoryPage : ContentPage
	{
		public SelectedCategoryPage ()
		{
			InitializeComponent ();
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var categoryItem = (CategoryItem)BindingContext;
            await App.Database.DeleteCategoryAsync(categoryItem);
            await Navigation.PopAsync();
        }
    }
}