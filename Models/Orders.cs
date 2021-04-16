using System;
using System.Collections.Generic;

namespace TestApp.Models {
    public class Orders {
        public OrderPayload Payload { get; set; } = new();
    }

    public class OrderPayload {
        public List<Order> Orders { get; set; } = new();
    }

    public class Order {
        public bool Visible { get; set; }
        public long Quantity { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public User User { get; set; } = new();
        public DateTimeOffset LastUpdate { get; set; }
        public long Platinum { get; set; }
        public OrderType OrderType { get; set; }
        public Region Region { get; set; }
        public Platform Platform { get; set; }
        public string Id { get; set; } = "";
        public long ModRank { get; set; }
    }

    public class User {
        public string IngameName { get; set; } = "";
        public DateTimeOffset LastSeen { get; set; }
        public long Reputation { get; set; }
        public Region Region { get; set; }
        public string Avatar { get; set; } = "";
        public Status Status { get; set; }
        public string Id { get; set; } = "";
    }

    public enum OrderType {
        Sell
    }

    public enum Platform {
        Pc
    }

    public enum Region {
        De,
        En
    }

    public enum Status {
        Ingame,
        Offline,
        Online
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