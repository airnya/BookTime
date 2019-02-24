using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using TextSix.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemAdded : ContentPage
    {
        public Item Item { get; set; }

        public NewItemAdded()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "",
                Description = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}
