namespace VideoCatalog.Common
{
    using VideoCatalog.ViewModels;

    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => new MainViewModel(App.Navigation);
    }
}
