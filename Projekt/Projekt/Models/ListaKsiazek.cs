using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Projekt.Models
{
    public class ListaKsiazek
    {
        [JsonProperty("ksiazki")]
        public List<BookList> Books { get; set; }
    }
}
