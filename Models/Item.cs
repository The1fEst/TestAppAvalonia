using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestApp.Models {
    public class ItemSpecs
    {
        public ItemSpecPayload Payload { get; set; }
    }

    public class ItemSpecPayload
    {
        public ItemSpec Item { get; set; }
    }

    public class ItemSpec
    {
        public string Id { get; set; }
        
        [JsonPropertyName("items_in_set")]
        public List<ItemsInSet> ItemsInSet { get; set; }
    }

    public class ItemsInSet
    {
        public string Id { get; set; }
        public string Thumb { get; set; }
        public string Icon { get; set; }
        public string Rarity { get; set; }
        public List<string> Tags { get; set; }
        [JsonPropertyName("mod_max_rank")]
        public long ModMaxRank { get; set; }
        [JsonPropertyName("trading_tax")]
        public long TradingTax { get; set; }
        [JsonPropertyName("url_name")]
        public string UrlName { get; set; }
        [JsonPropertyName("sub_icon")]
        public string SubIcon { get; set; }
        [JsonPropertyName("icon_format")]
        public string IconFormat { get; set; }
        public Language En { get; set; }
        public Language Ru { get; set; }
        public Language Ko { get; set; }
        public Language Fr { get; set; }
        public Language Sv { get; set; }
        public Language De { get; set; }
        [JsonPropertyName("zh-hant")]
        public Language ZhHant { get; set; }
        [JsonPropertyName("zh-hans")]
        public Language ZhHans { get; set; }
        public Language Pt { get; set; }
        public Language Es { get; set; }
        public Language Pl { get; set; }
    }

    public class Language
    {
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("wiki_link")]
        public Uri WikiLink { get; set; }
        public string Icon { get; set; }
        public string Thumb { get; set; }
        public List<Drop> Drop { get; set; }
    }

    public class Drop {
        public string Name { get; set; }
        public string Link { get; set; }
    }
}