using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.IO;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Net;
using System.Text;
using Windows.Media.Playback;
using Windows.Media.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3 {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            string url = "https://birdjiujiuuu.github.io/magicapp/source/winui3/home/bgm.txt";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myresponsestream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(myresponsestream, Encoding.UTF8);
            string retString = streamReader.ReadToEnd();
            streamReader.Close();
            myresponsestream.Close();
            int Ida = retString.IndexOf("<id>");
            int Idb = retString.IndexOf("</id>");
            string BgmMedia = "https://music.163.com/song/media/outer/url?id=" + retString.Substring(Ida + 4, Idb - Ida - 4) + ".mp3";
            int BgmNamea = retString.IndexOf("<name>");
            int BgmNameb = retString.IndexOf("</name>");
            string BgmNameab = retString.Substring(BgmNamea + 6, BgmNameb - BgmNamea - 6);
            int BgmAuthora = retString.IndexOf("<artist>");
            int BgmAuthorb = retString.IndexOf("</artist>");
            string BgmAuthorab = retString.Substring(BgmAuthora + 8, BgmAuthorb - BgmAuthora - 8);
            int Covera = retString.IndexOf("<cover>");
            int Coverb = retString.IndexOf("</cover>");
            string Cover = retString.Substring(Covera + 7, Coverb - Covera - 7);
            //各种抓取和解析
            BitmapImage Pictures = new BitmapImage();
            Pictures.UriSource = new Uri(this.BaseUri, Cover);
            Picture.Source = Pictures;
            BgmName.Text = BgmNameab;
            BgmAuthor.Text = BgmAuthorab;
            //将抓取信息填入播放信息框
            var mediaPlayer = new MediaPlayer();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(BgmMedia));
            mediaPlayer.Play();
            //播放Bgm
            mediaPlayer.Volume = 0.5;
            //设置音量
        }
    }
}
