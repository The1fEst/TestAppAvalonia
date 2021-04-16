using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;

namespace TestApp.Controllers {
    public class NavigationController<T> where T : notnull {
        private readonly List<Control> _story = new();
        private readonly Dictionary<T, Control> _views;
        private readonly Panel _workspace;

        public NavigationController(Panel workspace, Dictionary<T, Control>? views = null) {
            _workspace = workspace;
            _views = views ?? new();
        }

        public void NavigateTo(T viewKey, Control? back = null) {
            if (!_views.ContainsKey(viewKey)) return;

            var view = _views[viewKey];

            _workspace.Children.Clear();
            _workspace.Children.Add(view);

            if (back != null) _story.Add(back);
        }

        public void NavigateTo(Control view, Control? back = null) {
            _workspace.Children.Clear();
            _workspace.Children.Add(view);

            if (back != null) _story.Add(back);
        }

        public void Back() {
            var view = _story.LastOrDefault();
            if (view == null) return;

            _story.Remove(view);
            _workspace.Children.Clear();
            _workspace.Children.Add(view);
        }
    }
}