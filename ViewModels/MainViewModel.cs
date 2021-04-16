using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Avalonia.Threading;
using DynamicData;
using ReactiveUI;
using TestApp.Models;
using Item = TestApp.Views.Item;

namespace TestApp.ViewModels {
    public class MainViewModel : ViewModelBase {
        public readonly SourceList<ListBoxItemData> _allAvailableItems;
        private readonly ReadOnlyObservableCollection<ListBoxItemData> _availableItems;
        private string _searchText = null!;

        public MainViewModel() {
            _allAvailableItems = new SourceList<ListBoxItemData>();

            var filter = this.WhenAnyValue(vm => vm.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Select(BuildFilter);

            _allAvailableItems.Connect()
                .Filter(filter)
                .ObserveOn(AvaloniaScheduler.Instance)
                .Bind(out _availableItems)
                .Subscribe();
        }

        public ReadOnlyObservableCollection<ListBoxItemData> AvailableItems => _availableItems;
        public SourceList<ListBoxItemData> AllAvailableItems => _allAvailableItems;

        public string SearchText {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public void PrepareAvailableItems(IEnumerable<ListBoxItemData> items) {
            _allAvailableItems.Edit(l => {
                l.Clear();
                l.AddRange(items);
            });
        }

        private Func<ListBoxItemData, bool> BuildFilter(string searchText) {
            if (string.IsNullOrEmpty(searchText)) return _ => true;

            return t => t.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }

        public void OpenItem(string url) {
            App.Navigation?.NavigateTo(new Item(url));
        }
    }
}