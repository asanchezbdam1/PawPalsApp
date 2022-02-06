using CrossClasses;
using PawPalsApp.Classes;
using PawPalsApp.Resx;
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
            Task.Run(async () =>
            {
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
            });
        }

        private void Actualizar()
        {
            Posts.Clear();
            ConnectionHelper.Send(new PostList());
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            Actualizar();
            ((RefreshView)sender).IsRefreshing = false;
        }

        private async void PickPost()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.IsSupported)
            {
                await DisplayAlert("No está soportado", "Error", "Back");
                return;
            }
            var opt = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 25
            };
            var img = await CrossMedia.Current.PickPhotoAsync(opt);
            if (img == null) return;
            byte[] buf = new byte[img.GetStream().Length];
            img.GetStream().Read(buf, 0, buf.Length);
            if (buf.Length > ConnectionHelper.MAX_IMAGE_SIZE)
            {
                DisplayAlert(AppResources.ErrorTitle, AppResources.ImageSizeError, AppResources.Back);
                return;
            }
            Post p = new Post
            {
                Username = ((App)App.Current).User.Login,
                Img = buf
            };
            Posts.Add(p);
        }

        private void btnAdd_Pressed(object sender, EventArgs e)
        {
            PickPost();
        }

        private void btnHistorial_Pressed(object sender, EventArgs e)
        {

        }
    }
}