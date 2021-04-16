using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI;
using TestApp.Utils;
using TestApp.ViewModels;

namespace TestApp.Models {
    public class ListBoxItemData : ViewModelBase {
        private Bitmap? _icon;

        public ListBoxItemData(string name, string url, string icon) {
            Name = name;
            Url = url;

            Task.Run(() => GetIcon(icon));
        }

        public ListBoxItemData(string name, string url) {
            Name = name;
            Url = url;
        }

        public string Url { get; set; }
        public string Name { get; set; }

        public Bitmap? Icon {
            get => _icon;
            set => this.RaiseAndSetIfChanged(ref _icon, value);
        }

        private async Task GetIcon(string url) {
            Icon = await IconUtils.GetIcon(url);
        }

        public void OpenItem(Control view) {
            App.Navigation?.NavigateTo(new Views.Item(Url), view);
        }
    }
}