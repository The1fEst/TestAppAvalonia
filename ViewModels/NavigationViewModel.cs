using System;
using System.Collections.Generic;
using Avalonia.Controls;
using TestApp.Models.Constants;

namespace TestApp.ViewModels {
    public class NavigationViewModel : ViewModelBase {
        public string Name { get; set; } = "Program";

        public string BackName { get; set; } = "<-";

        public Dictionary<ViewEnum, string> NavItems { get; set; } = new();

        public void Back() {
        }
    }
}