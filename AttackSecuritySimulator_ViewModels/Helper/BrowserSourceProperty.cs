using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Allows data binding of the web browser's source property
    /// 
    /// Reference:  https://github.com/thoemmi/WebBrowserHelper
    /// 
    /// Notes:      Ended up not using this method to change the source property as there
    ///             was another way to do it.
    ///             However the process of creating properties on Controls that can't normally be binded
    ///             is the same.
    /// </summary>
    public static class BrowserSourceProperty
    {
        //Create Property
        public static readonly DependencyProperty BindedSource =
            DependencyProperty.RegisterAttached("BindedSource", typeof(string), typeof(InGameViewModel), new UIPropertyMetadata(null, OnBindedSourcePropertyChanged));
        //Property Getter
        public static string GetBindedSource(DependencyObject dObj)
        {
            return (string)dObj.GetValue(BindedSource);
        }
        //Property Setter
        public static void SetBindedSource(DependencyObject dObj, string value)
        {
            dObj.SetValue(BindedSource, value);
        }
        //Property OnChanged Call back
        public static void OnBindedSourcePropertyChanged(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = dObj as WebBrowser;
            if (browser != null)
            {
                string uri = e.NewValue as string;
                browser.Source = new Uri($@"{uri}");
            }
        }
    }
}
