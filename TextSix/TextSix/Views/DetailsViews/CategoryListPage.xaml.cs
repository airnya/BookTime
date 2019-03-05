using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using TextSix.Views.DetailsViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryListPage : ContentPage
    {
        public CategoryListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listViewCategory.ItemsSource = await App.Database.GetCategoriesAsync();
        }
//при нажатии на плюс
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryItemPage
            {
                BindingContext = new CategoryItem()
            });
        }
//при нажатии на элемент в списке
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CategoryItemPage
                {
                    BindingContext = e.SelectedItem as CategoryItem
                });
            }
        }

        async void OnListMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CategoryItemPage
                {
                    BindingContext = e.SelectedItem as CategoryItem
                });
            }
        }

        public async void OnDeleteClicked(object sender, EventArgs e)            
        {
            try
            {
                var todoItem = (CategoryItem)BindingContext;
                await App.Database.DeleteCategoryAsync(todoItem);
                await Navigation.PopAsync();
            }
            catch (Exception s) 
            {
                throw;
            }

        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        async void OnDelete(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CategoryItemPage
                {
                    BindingContext = e.SelectedItem as CategoryItem
                });
            }
        }
    }
}
