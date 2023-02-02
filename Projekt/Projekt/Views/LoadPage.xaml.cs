using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Projekt.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using MonkeyCache.FileStore;

namespace Projekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        public LoadPage()
        {
            Barrel.ApplicationId = "Zapisywanie cache";
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var books = await GetBooks();
            
            if (books != null)
            {
                listaPolecanych.ItemsSource = books.Books;
            }

        }
        private async Task<ListaKsiazek> GetBooks()
        {
            try
            {
                var books = new ListaKsiazek();
                books.Books = new List<BookList>();
                const string url = "https://api.npoint.io/3af3e88339851fb342cc";

                if (Connectivity.NetworkAccess != NetworkAccess.Internet && Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    return Barrel.Current.Get<ListaKsiazek>(key: url);
                }

                using (var httpClient = new HttpClient())
                {
                    var booksJson = await httpClient.GetStringAsync("https://api.npoint.io/3af3e88339851fb342cc");
                    books = JsonConvert.DeserializeObject<ListaKsiazek>(booksJson);
                }

                Barrel.Current.Add(key: url, data: books, expireIn: TimeSpan.FromMinutes(60));
                return books;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }
}
