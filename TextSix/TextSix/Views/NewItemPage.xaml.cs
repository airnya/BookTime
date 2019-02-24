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
    public partial class NewItemPage : TabbedPage
    {
        public NewItemPage()
        {
            InitializeComponent();
        }
    }
}