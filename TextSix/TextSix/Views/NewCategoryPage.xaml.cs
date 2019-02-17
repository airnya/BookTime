using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCategoryPage : ContentPage
    {
        public Category Category { get; set; }

        public NewCategoryPage()
        {
            InitializeComponent();

            Category = new Category
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Category);
            await Navigation.PopModalAsync();
        }
    }
}
