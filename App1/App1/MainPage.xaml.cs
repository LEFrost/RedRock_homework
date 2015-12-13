using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace App1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new test();
        }
        public ObservableCollection<test> mOC = new ObservableCollection<test>();


        private  void mbutton_Click(object sender, RoutedEventArgs e)
        {
            if (mtextbox.Text == "")
            {
                
            }
            else
            {
                mOC.Add(new test { Text = mtextbox.Text });
                mlistView.ItemsSource = mOC;
          
            }

        }

        private async void mlistView_ItemClick(object sender, ItemClickEventArgs e)
        {
            await new MessageDialog(((test)e.ClickedItem).Text).ShowAsync();
        }
    }
    public class test
    {

        public string Text
        {
            get; set;
        }

    }
    public class mconverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value=="")
            {
                return value.ToString();
            }
            else
            {
                return value.ToString() + "牌";
            }
        }
              
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }
    }
}
