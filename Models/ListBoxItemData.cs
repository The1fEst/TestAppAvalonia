namespace TestApp.Models {
    public class ListBoxItemData {
        public ListBoxItemData(string name, string url) {
            Name = name;
            Url = url;
        }
        
        public string Name { get; set; }
        public string Url { get; set; }

        public void OpenItem() => App.Navigation?.NavigateTo(new Views.Item(Url));
    }
}