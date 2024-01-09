using System.Windows.Input;
using VideoCatalog.Common;
using VideoCatalog.Models;

namespace VideoCatalog.ViewModels
{
    public interface IMainViewModel
    {
        VideoItem CurrentVideoItem {  get; set; }
    }
}
