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
        private ObservableCollection<Post> posts;
        public CuteOMeter()
        {
            InitializeComponent();
            posts = new ObservableCollection<Post>();
            lvPosts.ItemsSource = posts;
            List<Post> list = new List<Post>();
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
                list.Add(post);
                list.Add(new Post
                {
                    Username = "Prueba2",
                    Likes = 10,
                    Dislikes = 3,
                    Img = img
                });
                list.Add(new Post
                {
                    Username = "Prueba3",
                    Likes = 10,
                    Dislikes = 3,
                    Img = img
                });
            }
            DisplayAlert("La concha de la lora", "FUNCIONA", "VOLVER");
        }
    }
}