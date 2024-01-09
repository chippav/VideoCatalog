namespace VideoCatalog
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Controls;
    using VideoCatalog.Common;
    using VideoCatalog.ViewModels;
    using VideoCatalog.Views;

    public class NavigationService : INavigationService
    {
        readonly Frame frame;

        private string _CurrentView;

        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        public string CurrentView { get => _CurrentView; }

        public void GoBack()
        {
            if(CurrentView == nameof(VideoView))
            {
                _CurrentView = null;
            }
            frame.GoBack();
        }

        public void GoForward()
        {
            frame.GoForward();
        }

        public bool Navigate<T>(object parameter = null)
        {
            var type = typeof(T);
            return Navigate(type, parameter);
        }

        public bool Navigate(Type source, object parameter = null)
        {
            var src = Activator.CreateInstance(source);
            return frame.Navigate(src, parameter);
        }

        public bool Navigate(string page)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(a => a.Name.Equals(page));
            if (type == null) return false;
            this._CurrentView = page;
            var src = Activator.CreateInstance(type);
            this.frame.DataContext = src;
            return frame.Navigate(src);
        }

        public bool Navigate(string page, IMainViewModel viewModel)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(a => a.Name.Equals(page));
            if (type == null) return false;
            this._CurrentView = page;
            var src = Activator.CreateInstance(type);
            if(src is VideoView view)
            {
               view.DataContext = viewModel;
            }
            
            return frame.Navigate(src);
        }
    }
}
