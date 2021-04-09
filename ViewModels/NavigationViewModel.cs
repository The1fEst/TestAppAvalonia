using System;
using System.Collections.Generic;

namespace TestApp.ViewModels {
    public class NavigationViewModel : ViewModelBase {
        public string Name { get; set; } = "Program";

        public string BackName { get; set; } = "<-";

        public Dictionary<string, Action> NavItems { get; set; } = new();

        public void Back() {
        }
    }
}