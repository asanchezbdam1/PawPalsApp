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
        public PostsViewCollection<Post> Posts { get; set; } = new PostsViewCollection<Post>();
        public CuteOMeter()
        {
            InitializeComponent();
            lvPosts.ItemsSource = Posts;
        }

        private void Actualizar(bool viewed)
        {
            var pl = ConnectionHelper.Send(new PostList() {
                RequesterID = ((App)App.Current).User.Id,
                History = viewed
            }) as PostList;
            if (pl.Posts.Count != 0)
            {
                Posts.Clear();
                foreach (var it in pl.Posts)
                {
                    Posts.Add(it);
                }
            }
            rvPosts.IsRefreshing = false;
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                Actualizar(false);
            });
        }

        private async void PickPost()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.IsSupported)
            {
                await DisplayAlert("Error", AppResources.ErrorTitle, AppResources.Back);
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
            Task.Run(async () =>
            {
                Actualizar(true);
            });
        }

        private void btnDislike_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            if (p.Reaction == PostReaction.LIKE) p.Likes--;
            p.Reaction = PostReaction.DISLIKE;
            React(p);
        }

        private void btnDisliked_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            p.Dislikes--;
            p.Reaction = PostReaction.NONE;
            React(p);
        }

        private void btnLike_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            if (p.Reaction == PostReaction.DISLIKE) p.Dislikes--;
            p.Reaction = PostReaction.LIKE;
            React(p);
        }

        private void btnLiked_Pressed(object sender, EventArgs e)
        {
            var imb = (ImageButton)sender;
            Post p = imb.BindingContext as Post;
            p.Likes--;
            p.Reaction = PostReaction.NONE;
            React(p);
        }

        private void React(Post p)
        {
            PostReacted pr = new PostReacted
            {
                PostID = p.ID,
                Reaction = p.Reaction,
                UserID = ((App)App.Current).User.Id
            };
            Task.Run(() => {
                try
                {
                    var res = (PostReaction)ConnectionHelper.Send(pr);
                    if (res != p.Reaction)
                    {
                        p.Reaction = res;
                        throw new Exception();
                    }
                    if (p.Reaction == PostReaction.LIKE) p.Likes++;
                    else if (p.Reaction == PostReaction.DISLIKE) p.Dislikes++;

                } catch { }
            });
        }
    }
}