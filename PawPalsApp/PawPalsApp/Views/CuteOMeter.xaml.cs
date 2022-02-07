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
            lvPosts.ItemsSource = Posts;
        }

        private void Actualizar()
        {
            var pl = ConnectionHelper.Send(new PostList()) as PostList;
            if (pl.Posts.Count == 0) DisplayAlert(AppResources.ErrorTitle, AppResources.RefreshError, AppResources.Back);
            else
            {
                Posts.Clear();
                foreach (var it in pl.Posts)
                {
                    Posts.Add(it);
                }
            }
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Actualizar();
                ((RefreshView)sender).IsRefreshing = false;
            });
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
                UID = ((App)App.Current).User.Id,
                Img = buf
            };
            Task.Run(() => { ConnectionHelper.Send(p); } );
            
        }

        private void btnAdd_Pressed(object sender, EventArgs e)
        {
            PickPost();
        }

        private void btnHistorial_Pressed(object sender, EventArgs e)
        {

        }

        private void btnDislike_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            p.Reaction = PostReaction.DISLIKE;
        }

        private void btnDisliked_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            p.Reaction = PostReaction.NONE;
        }

        private void btnLike_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            p.Reaction = PostReaction.LIKE;
        }

        private void btnLiked_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            p.Reaction = PostReaction.NONE;
        }

        private void Update()
        {
            /*List<Post> posts = new List<Post>();
            foreach (Post p in Posts)
            {
                posts.Add(p);
            }
            Posts.Clear();
            foreach (Post p in posts)
            {
                Posts.Add(p);
            }*/
        }
    }
}