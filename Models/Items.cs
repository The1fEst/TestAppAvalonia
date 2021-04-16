using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestApp.Models {
    public class Items {
        public ItemPayload Payload { get; set; } = new();
    }

    public class ItemPayload {
        public List<Item> Items { get; set; } = new();
    }

    public class Item {
        public delegate void OnOpenItem(string message);

        public string Id { get; set; } = "";

        [JsonPropertyName("url_name")] public string UrlName { get; set; } = "";

        [JsonPropertyName("item_name")] public string ItemName { get; set; } = "";

        public string Thumb { get; set; } = "";

        public event OnOpenItem? Open;

        public void OpenItem(string message) {
            Open?.Invoke(message);
        }
    }
}