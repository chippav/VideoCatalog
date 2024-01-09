using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoCatalog.ViewModels;

namespace VideoCatalog.Common
{
    public interface INavigationService
    {
        void GoForward();
        void GoBack();
        bool Navigate(string page);
        bool Navigate(string page, IMainViewModel viewModel);
        string CurrentView { get; } 
    }
}
