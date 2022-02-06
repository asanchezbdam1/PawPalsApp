using CrossClasses;
using PawPalsApp.Classes;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CuteOMeter : ContentPage
    {
        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();
        public CuteOMeter()
        {
            InitializeComponent();
            using (var webClient = new WebClient())
            {
                var img = webClient.DownloadData("http://www.google.com/images/logos/ps_logo2.png");
                Post post = new Post
                {
                    Username = "Prueba",
                    Likes = 10,
                    Dislikes = 3
                };
                post.Img = img;
                Posts.Add(post);
                Posts.Add(new Post
                {
                    Username = "Prueba2",
                    Likes = 10,
                    Dislikes = 3,
                    Img = img
                });
                Posts.Add(new Post
                {
                    Username = "Prueba3",
                    Likes = 10,
                    Dislikes = 3,
                    Img = img
                });
            }
            lvPosts.ItemsSource = Posts;
        }

        private void Actualizar()
        {
            Posts.Clear();
            ConnectionHelper.Send(new PostList());
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            Actualizar();
            PickPost();
            ((RefreshView)sender).IsRefreshing = false;
        }

        private async void PickPost()
        {
            await CrossMedia.Current.Initialize();
            var opt = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var img = await CrossMedia.Current.PickPhotoAsync();
            byte[] buf = new byte[10  * 1024 * 1024];
            img.GetStream().Read(buf, 0, buf.Length);
            while (buf.Length > ConnectionHelper.MAX_IMAGE_SIZE)
            {
                buf = ImageCompressor.Compress(buf);
            }
            Post p = new Post
            {
                Username = ((App)App.Current).User.Login,
                Img = buf
            };
            Posts.Add(p);
        }
    }
}