using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestApp.Models {
    public class Orders {
        [JsonPropertyName("payload")] public Payload Payload { get; set; }
    }

    public class Payload {
        [JsonPropertyName("orders")] public List<Order> Orders { get; set; }
    }

    public class Order {
        [JsonPropertyName("order_type")] public string OrderType { get; set; }

        [JsonPropertyName("quantity")] public long Quantity { get; set; }

        [JsonPropertyName("visible")] public bool Visible { get; set; }

        [JsonPropertyName("platinum")] public float Platinum { get; set; }

        [JsonPropertyName("user")] public User User { get; set; }

        [JsonPropertyName("platform")] public string Platform { get; set; }

        [JsonPropertyName("region")] public string Region { get; set; }

        [JsonPropertyName("creation_date")] public DateTimeOffset CreationDate { get; set; }

        [JsonPropertyName("last_update")] public DateTimeOffset LastUpdate { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("mod_rank")] public long ModRank { get; set; }
    }

    public class User {
        [JsonPropertyName("reputation")] public long Reputation { get; set; }

        [JsonPropertyName("region")] public string Region { get; set; }

        [JsonPropertyName("last_seen")] public DateTimeOffset LastSeen { get; set; }

        [JsonPropertyName("ingame_name")] public string IngameName { get; set; }

        [JsonPropertyName("avatar")] public string Avatar { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }
    }

    public enum OrderType {
        Sell,
        Buy,
    }

    public class Achievement {
        public string Name { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Exposed { get; set; }
        public string Type { get; set; } = "";
    }

    public class LinkedAccounts {
        public bool SteamProfile { get; set; }
        public bool XboxProfile { get; set; }
        public bool PatreonProfile { get; set; }
    }
}