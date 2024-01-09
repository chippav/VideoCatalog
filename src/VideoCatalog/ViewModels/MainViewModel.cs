using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoCatalog.Common;
using VideoCatalog.Models;
using VideoCatalog.Services;
using VideoCatalog.Views;

namespace VideoCatalog.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Properties

        private List<VideoItem> _VideosList;
        public List<VideoItem> VideosList
        {
            get { return _VideosList; }
            set 
            {
                if (_VideosList != value)
                {
                    _VideosList = value;
                    this.OnPropertyChanged(nameof(VideosList));
                }
            }
        }

        private int _SelectedVideoIndex;
        public int SelectedVideoIndex
        {
            get { return _SelectedVideoIndex; }
            set 
            {
                if (_SelectedVideoIndex != value)
                {
                    _SelectedVideoIndex = value;
                    if (value >= 0)
                    {
                        CurrentVideoItem = VideosList[value];
                        if (this.navigationService.CurrentView != nameof(VideoView))
                        {
                            this.navigationService.Navigate(nameof(VideoView), this);
                        }
                    }
                }
            }
        }

        private VideoItem _CurrentVideoItem;
        public VideoItem CurrentVideoItem
        {
            get { return _CurrentVideoItem; }
            set
            {
                if (_CurrentVideoItem != value)
                {
                    _CurrentVideoItem = value;
                    this.OnPropertyChanged(nameof(CurrentVideoItem));
                }
            }
        }

        private readonly INavigationService navigationService;

        private bool _IsShowNetworkError;
        public bool IsShowNetworkError
        {
            get { return _IsShowNetworkError; }
            set
            {
                if (_IsShowNetworkError != value)
                {
                    _IsShowNetworkError = value;
                    this.OnPropertyChanged(nameof(IsShowNetworkError));
                }
            }
        }


        #endregion

        #region Constructor

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        #endregion

        #region PrivateMethods

        private void RefreshData()
        {
            try
            {
                string jsonResponse = VideoApiService.Instance.GetJsonVideoResponseAsync(Properties.Settings.Default.GetVideosUrl).Result;
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    IsShowNetworkError = false;
                    var videos = JsonConvert.DeserializeObject<IEnumerable<VideoItem>>(jsonResponse);
                    VideosList = videos.OrderBy(x => x.Title).ToList();
                }
            }
            catch (Exception ex)
            {
                {
                    IsShowNetworkError = true;
                }
            }
        }

        private void ShowLeftVideo()
        {
            if(SelectedVideoIndex > 0)
            { 
                SelectedVideoIndex--; 
            }
        }

        private void ShowRightVideo()
        {
            if (SelectedVideoIndex < VideosList.Count-1 )
            {
                SelectedVideoIndex++;
            }
        }

        #endregion

        #region Commands

        public ICommand OnLoadedCommand
        {
            get { return new DelegateCommand(x => Task.Factory.StartNew(() => { RefreshData(); })); }
        }

        public ICommand NavigateBackCommand
        {
            get { return new DelegateCommand(x => { this.navigationService.GoBack(); }); }
        }
        

        public ICommand LeftVideoCommand
        {
            get { return new DelegateCommand(x => { ShowLeftVideo(); }, y=> { return !(SelectedVideoIndex == 0);  } ); }
        }

        public ICommand RightVideoCommand
        {
            get { return new DelegateCommand(x => { ShowRightVideo(); }, y => { return !(SelectedVideoIndex == VideosList.Count-1); }); }
        }

        #endregion


    }
}
