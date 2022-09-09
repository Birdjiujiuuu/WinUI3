using ABI.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Uri = System.Uri;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3.sources.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            ComboBox.SelectedValue = "Google";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SourceWeb = e.AddedItems[0].ToString();
            if (SourceWeb == "Google")
            {
                Text.Text = "Google";
                BitmapImage Icons = new BitmapImage();
                Icons.UriSource = new Uri(this.BaseUri, "https://www.google.cn/favicon.ico");
                Icon.Source = Icons;
            }

            else if (SourceWeb == "Bing")
            {
                Text.Text = "Bing";
                BitmapImage Icons = new BitmapImage();
                Icons.UriSource = new Uri(this.BaseUri, "https://cn.bing.com/favicon.ico");
                Icon.Source = Icons;
            }

            else if (SourceWeb == "百度")
            {
                Text.Text = "百度";
                BitmapImage Icons = new BitmapImage();
                Icons.UriSource = new Uri(this.BaseUri, "https://www.baidu.com/favicon.ico");
                Icon.Source = Icons;
            }
            this.SearchBox_TextChanged(null,null);
        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (Text.Text == "Google")
            {
                string url = "https://www.google.com/search?q=" + SearchBox.Text;
                Uri targetUri = new Uri(url);
                explorer.Source = targetUri;
            }

            else if (Text.Text == "Bing")
            {
                string url = "https://www.bing.com/search?q=" + SearchBox.Text;
                Uri targetUri = new Uri(url);
                explorer.Source = targetUri;
            }

            else if (Text.Text == "百度")
            {
                string url = "https://www.baidu.com/s?wd=" + SearchBox.Text;
                Uri targetUri = new Uri(url);
                explorer.Source = targetUri;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "Google")
            {
                string url = "https://www.google.com/search?q=" + SearchBox.Text;
                System.Diagnostics.Process.Start("explorer.exe",url);
            }

            else if (Text.Text == "Bing")
            {
                string url = "https://www.bing.com/search?q=" + SearchBox.Text;
                System.Diagnostics.Process.Start("explorer.exe",url);
            }

            else if (Text.Text == "百度")
            {
                string url = "https://www.baidu.com/s?wd=" + SearchBox.Text;
                System.Diagnostics.Process.Start("explorer.exe",url);
            }
        }
    }
}
