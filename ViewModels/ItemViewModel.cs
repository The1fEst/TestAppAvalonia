using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using DynamicData;
using ReactiveUI;
using TestApp.Models;

namespace TestApp.ViewModels {
    public class ItemViewModel : ViewModelBase {
        public ObservableCollection<NamedIcon> AllAvailableItems { get; set; }

        public ItemViewModel() {
            AllAvailableItems = new();
        }

        public string Url { get; init; }

        private List<NamedIcon> _items;

        public List<NamedIcon> Items {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }
    }
}