using System.Collections.Generic;
using Avalonia.Controls;
using Window = Avalonia.Controls.Window;

namespace TestApp.Controllers {
    public class NavigationController<T> where T : notnull {
        private readonly Dictionary<T, Control> _views;
        private readonly Panel _workspace;

        public NavigationController(Panel workspace, Dictionary<T, Control>? views = null) {
            _workspace = workspace;
            _views = views ?? new();
        }

        public void NavigateTo(T viewKey) {
            if (!_views.ContainsKey(viewKey)) return;
            
            var view = _views[viewKey];

            _workspace.Children.Clear();
            _workspace.Children.Add(view);
        }
        
        public void NavigateTo(Control view) {
            _workspace.Children.Clear();
            _workspace.Children.Add(view);
        }
    }
}