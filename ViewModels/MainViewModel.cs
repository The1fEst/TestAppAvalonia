using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using Avalonia.Media;
using Avalonia.Threading;
using DynamicData;
using ReactiveUI;

namespace TestApp.ViewModels {
    public class MainViewModel : ViewModelBase {
        private readonly ReadOnlyObservableCollection<KeyValuePair<string, string>> _availableItems;
        private readonly SourceList<KeyValuePair<string, string>> _allAvailableItems;
        private string _searchText;

        public ReadOnlyObservableCollection<KeyValuePair<string, string>> AvailableItems => _availableItems;

        public string SearchText {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public MainViewModel() {
            _allAvailableItems = new SourceList<KeyValuePair<string, string>>();

            var filter = this.WhenAnyValue(vm => vm.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Select(BuildFilter);

            _allAvailableItems.Connect()
                .Filter(filter)
                .ObserveOn(AvaloniaScheduler.Instance)
                .Bind(out _availableItems)
                .Subscribe();
        }

        public void PrepareAvailableItems(IEnumerable<KeyValuePair<string, string>> items) {
            _allAvailableItems.Edit(l => {
                l.Clear();
                l.AddRange(items);
            });
        }

        private Func<KeyValuePair<string, string>, bool> BuildFilter(string searchText) {
            if (string.IsNullOrEmpty(searchText)) {
                return _ => true;
            }

            return t => t.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}