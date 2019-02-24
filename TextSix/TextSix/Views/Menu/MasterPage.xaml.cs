using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSix.Models;
using TextSix.Views;
using TextSix.Views.DetailsViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextSix.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Имя_Категории", "icon.png", "Автор?", Color.WhiteSmoke, typeof(InfoScreen)));
            items.Add(new MasterMenuItem("Коллекция", "icon.png", "Авторы?", Color.WhiteSmoke, typeof(InfoScreen2)));
            items.Add(new MasterMenuItem("Добавить книгу", "icon.png", "", Color.WhiteSmoke, typeof(NewItemPage)));

            ListView.ItemsSource = items;
        }
    }
}