using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ASM.Entity;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Upload : Page
    {
        private string UploadUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
        public Upload()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var song = new Song
            {
                name = this.Name.Text,
                description = this.Description.Text,
                singer = this.Singer.Text,
                author = this.Author.Text,
                thumbnail = this.Thumbnail.Text,
                link = this.Link.Text
            };
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(song),Encoding.UTF8,"application/json");
            var httpRequest = client.PostAsync(UploadUrl, content);
        }
    }
}
