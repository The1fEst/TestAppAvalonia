using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using Avalonia.Media;
using Avalonia.Threading;
using DynamicData;
using ReactiveUI;
using TestApp.Models;
using Item = TestApp.Views.Item;

namespace TestApp.ViewModels {
    public class MainViewModel : ViewModelBase {
        private readonly ReadOnlyObservableCollection<ListBoxItemData> _availableItems;
        private readonly SourceList<ListBoxItemData> _allAvailableItems;
        private string _searchText = null!;

        public ReadOnlyObservableCollection<ListBoxItemData> AvailableItems => _availableItems;

        public string SearchText {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

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

        public void PrepareAvailableItems(IEnumerable<ListBoxItemData> items) {
            _allAvailableItems.Edit(l => {
                l.Clear();
                l.AddRange(items);
            });
        }

        private Func<ListBoxItemData, bool> BuildFilter(string searchText) {
            if (string.IsNullOrEmpty(searchText)) {
                return _ => true;
            }

            return t => t.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }

        public void OpenItem(string url) {
            App.Navigation?.NavigateTo(new Item(url));
        }
    }
}