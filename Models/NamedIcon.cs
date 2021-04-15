using Avalonia.Media.Imaging;

namespace TestApp.Models {
    public class NamedIcon {
        public NamedIcon(string name, Bitmap icon) {
            Name = name;
            Icon = icon;
        }
        
        public string Name { get; set; }
        public Bitmap Icon { get; set; }
    }
}