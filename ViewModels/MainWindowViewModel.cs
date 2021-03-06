using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using Avalonia.Threading;
using DynamicData;
using ReactiveUI;

namespace TestApp.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        private readonly SourceList<(int, string)> _allAvailableItems;

        private readonly ReadOnlyObservableCollection<(int, string)> _availableItems;
        private string _icon = "fas fa-sun";
        private string _searchText;
        private string _selectedText;

        public MainWindowViewModel() {
            _allAvailableItems = new SourceList<(int, string)>();

            var filter = this.WhenAnyValue(vm => vm.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Select(BuildFilter);

            _allAvailableItems.Connect()
                .Filter(filter)
                .ObserveOn(AvaloniaScheduler.Instance)
                .Bind(out _availableItems)
                .Subscribe();
        }

        public string Icon {
            get => _icon;
            set => this.RaiseAndSetIfChanged(ref _icon, value);
        }

        public bool IsDay { get; set; } = true;

        public ReadOnlyObservableCollection<(int, string)> AvailableItems => _availableItems;

        public string SearchText {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public string SelectedText {
            get => _selectedText;
            set => this.RaiseAndSetIfChanged(ref _selectedText, value);
        }

        public void PrepareAvailableItems() {
            _allAvailableItems.Edit(l => {
                l.Clear();

                for (var i = 1; i < 500; i++) l.Add((i, $"lItem{i}"));

                l.Add((0, "Last"));
            });

            SelectedText = _availableItems.FirstOrDefault(i => i.Item1 == 0).Item2;
        }

        private Func<(int, string), bool> BuildFilter(string searchText) {
            if (string.IsNullOrEmpty(searchText)) return t => true;

            return t => t.Item2.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}