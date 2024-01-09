using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoCatalog.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        //IMainViewModel mvm=null;
        public MainView()
        {
            InitializeComponent();
            //mvm = this.DataContext as IMainViewModel;
            //this.Loaded += MainView_Loaded;
        }

        //private void MainView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if(mvm != null)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            mvm.RefreshData();

        //        });
        //    }
        //}
    }
}
