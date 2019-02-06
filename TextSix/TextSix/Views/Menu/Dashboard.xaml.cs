using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Views.DetailsViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard : ContentPage
	{
		public Dashboard ()
		{
			InitializeComponent ();            
		}
        async void SelectedMainScreen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen());
        }
	}
}