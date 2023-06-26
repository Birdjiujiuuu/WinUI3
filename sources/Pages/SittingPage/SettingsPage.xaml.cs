using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using WinUI3;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            string Version = string.Format("{0}.{1}.{2}.{3}",Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            AppVersion.Description = Version;
        }

        private void ColorMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Color = e.AddedItems[0].ToString();
            if (Color == "使用 Windows 默认")
            {
                
            }
            else if (Color == "浅色")
            {

            }
            else if(Color == "深色")
            {

            }
        }

        private async void CheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send("birdjiujiuuu.github.io");
            if (reply.Status == IPStatus.Success)
            {
                string url = "https://birdjiujiuuu.github.io/magicapp/history/version.html";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myresponsestream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myresponsestream, Encoding.UTF8);
                string retString = streamReader.ReadToEnd();
                streamReader.Close();
                myresponsestream.Close();
                int a = retString.IndexOf("winui3:");
                int b = retString.IndexOf(":winui3");
                string newestversion = retString.Substring(a + 7, b - a - 7);
                string version = string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
                if (newestversion == version)
                {
                    ContentDialog dialog = new ContentDialog();
                    dialog.XamlRoot = this.XamlRoot;
                    dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                    dialog.Title = "检查更新";
                    dialog.Content = "已经是最新版本！";
                    dialog.CloseButtonText = "确定";
                    dialog.DefaultButton = ContentDialogButton.Close;

                    var result = await dialog.ShowAsync();
                }
                else
                {
                    ContentDialog dialog = new ContentDialog();
                    dialog.XamlRoot = this.XamlRoot;
                    dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                    dialog.Title = "检查更新";
                    dialog.Content = "发现新版本！";
                    dialog.PrimaryButtonText = "前往下载";
                    dialog.CloseButtonText = "稍后下载";
                    dialog.DefaultButton = ContentDialogButton.Primary;

                    var result = await dialog.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        System.Diagnostics.Process.Start("explorer.exe", "https://github.com/Birdjiujiuuu/WinUI3/releases");
                    }
                    else
                    {
                        // Do nothing.
                    }
                }
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = this.XamlRoot;
                dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                dialog.Title = "检查更新";
                dialog.Content = "无法连接至服务器，请检查网络后重试";
                dialog.CloseButtonText = "确定";
                dialog.DefaultButton = ContentDialogButton.Close;

                var result = await dialog.ShowAsync();
            }
        }
    }
}
