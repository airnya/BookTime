using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using TextSix.Views.DetailsViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
        public ListView ListView { get { return ListView; } }
        public List<MasterMenuItem> items;

		public MasterPage ()
		{
			InitializeComponent ();
            SetItems();
		}

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Infoscreen1", "icon.png", "Say Mother Fucker", Color.White, typeof(InfoScreen)));
            items.Add(new MasterMenuItem("Infoscreen2", "icon.png", "Say Mother Fucker Fucker", Color.White, typeof(InfoScreen2)));
            ListView.ItemsSource = items;
        }
    }
}