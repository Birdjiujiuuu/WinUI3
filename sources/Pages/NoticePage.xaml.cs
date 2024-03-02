using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3.sources.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoticePage : Page
    {
        public NoticePage()
        {
            this.InitializeComponent();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText(ContectTitle.Text)
                .AddText(Contect.Text)
                .Show();
        }

        private async void PickLogo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PickPhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
