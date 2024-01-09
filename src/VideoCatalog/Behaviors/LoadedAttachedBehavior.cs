using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace VideoCatalog.Behaviors
{
    public static class LoadedAttachedBehavior
    {
        public static DependencyProperty LoadedCommandProperty
          = DependencyProperty.RegisterAttached(
               "LoadedCommand",
               typeof(ICommand),
               typeof(LoadedAttachedBehavior),
               new PropertyMetadata(null, OnLoadedCommandChanged));

        private static void OnLoadedCommandChanged
             (DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = depObj as FrameworkElement;
            if (frameworkElement != null && e.NewValue is ICommand)
            {
                frameworkElement.Loaded
                  += (o, args) =>
                  {
                      (e.NewValue as ICommand).Execute(null);
                  };
            }
        }

        public static ICommand GetLoadedCommand(DependencyObject depObj)
        {
            return (ICommand)depObj.GetValue(LoadedCommandProperty);
        }

        public static void SetLoadedCommand(
            DependencyObject depObj,
            ICommand value)
        {
            depObj.SetValue(LoadedCommandProperty, value);
        }
    }
}
