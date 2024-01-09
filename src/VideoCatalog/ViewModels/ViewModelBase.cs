using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoCatalog.Services;

namespace VideoCatalog.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public virtual async Task<bool> IsNetWorkConnected()
        {
            IVideoApiService videoApiService = VideoApiService.Instance;
            try
            {

                return await videoApiService.IsNetWorkConnected(Properties.Settings.Default.ConnectionUrl);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region PropertyChangedEvent 

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
