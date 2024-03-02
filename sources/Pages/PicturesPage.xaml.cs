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
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PicturesPage : Page
    {
        public PicturesPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            ComboBox.SelectedValue = "Bing";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SourceWeb = e.AddedItems[0].ToString();
            if (SourceWeb == "Bing")
            {
                string url = "https://cn.bing.com/HPImageArchive.aspx?idx=0&n=1";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myresponsestream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myresponsestream, Encoding.UTF8);
                string retString = streamReader.ReadToEnd();
                streamReader.Close();
                myresponsestream.Close();
                int a = retString.IndexOf("<url>");
                int b = retString.IndexOf("</url>");
                string imgurl = "http://cn.bing.com" + retString.Substring(a + 5, b - a - 5);
                //抓取每日一图url
                int InfoTitlea = retString.IndexOf("<headline>");
                int InfoTitleb = retString.IndexOf("</headline>");
                string InfoTitleab = retString.Substring(InfoTitlea + 10, InfoTitleb - InfoTitlea - 10);
                int InfoBodya = retString.IndexOf("<copyright>");
                int InfoBodyb = retString.IndexOf("</copyright>");
                string InfoBodyab = retString.Substring(InfoBodya + 11, InfoBodyb - InfoBodya - 11);
                //抓取信息
                BitmapImage Pictures = new BitmapImage();
                Pictures.UriSource = new Uri(this.BaseUri, imgurl);
                Picture.Source = Pictures;
                BitmapImage Icons = new BitmapImage();
                Icons.UriSource = new Uri(this.BaseUri, "https://cn.bing.com/favicon.ico");
                Icon.Source = Icons;
                InfoTitle.Text = InfoTitleab;
                InfoBody.Text = InfoBodyab;
            }
            else if (SourceWeb == "NASA")
            {
                string url = "https://api.nasa.gov/planetary/apod?api_key=ArinapLeN81diwrDMp8C3v8BYYz5eSgt9eOpXo7h";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myresponsestream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myresponsestream, Encoding.UTF8);
                string retString = streamReader.ReadToEnd();
                streamReader.Close();
                myresponsestream.Close();
                int a = retString.IndexOf("\"hdurl\":\"");
                int b = retString.IndexOf("\",\"media_type");
                string imgurl = retString.Substring(a + 9, b - a - 9);
                //抓取每日一图url
                int InfoTitlea = retString.IndexOf("\"title\":\"");
                int InfoTitleb = retString.IndexOf("\",\"url");
                string InfoTitleab = retString.Substring(InfoTitlea + 9, InfoTitleb - InfoTitlea - 9);
                int InfoBodya = retString.IndexOf("\"explanation\":\"");
                int InfoBodyb = retString.IndexOf("\",\"hdurl");
                string InfoBodyab = retString.Substring(InfoBodya + 15, InfoBodyb - InfoBodya - 15);
                //抓取信息
                BitmapImage Pictures = new BitmapImage();
                Pictures.UriSource = new Uri(this.BaseUri, imgurl);
                Picture.Source = Pictures;
                BitmapImage Icons = new BitmapImage();
                Icons.UriSource = new Uri(this.BaseUri, "https://apod.nasa.gov/favicon.ico");
                Icon.Source = Icons;
                InfoTitle.Text = InfoTitleab;
                InfoBody.Text = InfoBodyab;
            }
        }
    }
}
