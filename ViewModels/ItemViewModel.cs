using System.Collections.Generic;
using Avalonia.Media.Imaging;
using ReactiveUI;
using TestApp.Models;
using Item = TestApp.Views.Item;

namespace TestApp.ViewModels {
    public class ItemViewModel : ViewModelBase {
        private string _description;

        private Bitmap _icon;

        private List<ListBoxItemData> _items;

        private string _name;

        public ItemViewModel() {
            AllAvailableItems = new();
        }

        public List<ListBoxItemData> AllAvailableItems { get; set; }

        public string Url { get; init; }

        public List<ListBoxItemData> Items {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public string Name {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Description {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public Bitmap Icon {
            get => _icon;
            set => this.RaiseAndSetIfChanged(ref _icon, value);
        }

        private List<OrderItem> _buyOrders;

        public List<OrderItem> BuyOrders {
            get => _buyOrders;
            set => this.RaiseAndSetIfChanged(ref _buyOrders, value);
        }

        private List<OrderItem> _sellOrders;

        public List<OrderItem> SellOrders {
            get => _sellOrders;
            set => this.RaiseAndSetIfChanged(ref _sellOrders, value);
        }
    }
}