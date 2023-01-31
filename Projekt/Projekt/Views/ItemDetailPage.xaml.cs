using Projekt.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Projekt.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}