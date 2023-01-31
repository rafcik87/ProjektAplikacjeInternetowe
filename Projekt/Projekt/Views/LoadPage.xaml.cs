using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projekt.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Projekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        public LoadPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            var resultJson = await httpClient.GetStringAsync("https://api.npoint.io/3af3e88339851fb342cc");

            var result = JsonConvert.DeserializeObject<BookList[]>(resultJson);

            listaPolecanych.ItemsSource = result;
        }
    }
}
