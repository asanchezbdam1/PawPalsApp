using CrossClasses;
using PawPalsApp.Classes;
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
            //lvPosts.SetBinding(ListView.ItemsSourceProperty, "Posts");
            //lvPosts.ItemsSource = Posts;
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
                lvPosts.ItemsSource = Posts;
            }
        }
    }
}