using System;
using Newtonsoft.Json;

namespace Projekt.Models
{
    public class BookList
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("pages")]
        public string Pages { get; set; }

        [JsonProperty("cover")]
        public Uri Cover { get; set; }
    }
}

