using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawPalsApp.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Guide : ContentPage
    {
        
        public Guide()
        {
            InitializeComponent();
            Piqueador.Items.Add(AppResources.Diet);
            Piqueador.Items.Add(AppResources.Exercise);
            Piqueador.Items.Add(AppResources.Hygiene);
            
            Piqueador.SelectedIndex = 0;
            dietaPerros();
        }
        private void Piqueador_SelectedIndexChanged(object sender, EventArgs e)
        {
            slContenido.Children.Clear();
            if (Piqueador.SelectedIndex == 0)
            {
                if (!btnPerro.IsEnabled)
                {
                    dietaPerros();
                }
                else if (!btnGato.IsEnabled)
                {
                    dietaGatos();
                }
                else if (!btnRoedor.IsEnabled)
                {
                    dietaRoedores();
                }
            }
            else if(Piqueador.SelectedIndex == 1){
                if (!btnPerro.IsEnabled)
                {
                    ejercicioPerros();
                }
                else if (!btnGato.IsEnabled)
                {
                    ejercicioGatos();
                }
                else if (!btnRoedor.IsEnabled)
                {
                    ejercicioRoedores();
                }
            }
            else
            {
                if (!btnPerro.IsEnabled)
                {
                    higienePerros();
                }
                else if (!btnGato.IsEnabled)
                {
                    higieneGatos();
                }
                else if (!btnRoedor.IsEnabled)
                {
                    higieneRoedores();
                }
            }
        }
        private void dietaPerros()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutDiet, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutDiet }
                            }   
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleDogsDiet, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DogsDiet }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View) it);
            };

        }
        private void dietaGatos()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutDiet, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutDiet }
                            }

                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleCatsDiet, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.CatsDiet }
                            }

                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            }
        }
        private void dietaRoedores()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutDiet, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutDiet }
                            }

                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleRodentDiet, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.RodentDiet }
                            }

                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            }
        }
        private void ejercicioPerros()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutExercise, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutExercise }
                            }
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleDogsExercise, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DogsExercise }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            }
        }
        private void ejercicioGatos()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutExercise, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutExercise }
                            }
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleCatsExercise, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.CatsExercise }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            }
        }
        private void ejercicioRoedores()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutExercise, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutExercise }
                            }
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleRodentsExercise, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.RodentsExercise }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            }
        }
        private void higienePerros()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutHygiene, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutHygiene }
                            }
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleDogsHygiene, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DogsHygiene }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            };
        }
        private void higieneGatos()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutHygiene, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutHygiene }
                            }
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleCatsHygiene, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.CatsHygiene }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            };
        }
        private void higieneRoedores()
        {
            object[] items = {
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.AllAboutHygiene, FontSize=26},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.DescAllAboutHygiene }
                            }
                        }
                },
                new Frame()
                {
                    Content =
                        new StackLayout()
                        {
                            HorizontalOptions=LayoutOptions.Center,
                            Children =
                            {
                                new Label() { Text=AppResources.TitleRodentsHygiene, FontSize=22},
                                new BoxView(){ BackgroundColor= Color.Black,
                                            HeightRequest= 1 },
                                new Label() { Text=AppResources.RodentsHygiene }
                            }
                        }
                }

            };
            foreach (var it in items)
            {
                slContenido.Children.Add((View)it);
            };
        }

        private void btnPerro_Clicked(object sender, EventArgs e)
        {
            reiniciarIconos();
            btnPerro.Source = "DogIcon.png";
            btnPerro.IsEnabled = false;
            switch (Piqueador.SelectedIndex)
            {
                case 0:
                    dietaPerros();
                    break;
                case 1:
                    ejercicioPerros();
                    break;
                case 2:
                    higienePerros();
                    break;
            }
        }

        private void btnGato_Clicked(object sender, EventArgs e)
        {
            reiniciarIconos();
            btnGato.Source = "CatIcon.png";
            btnGato.IsEnabled = false;
            switch (Piqueador.SelectedIndex)
            {
                case 0: dietaGatos();
                    break;
                case 1:
                    ejercicioGatos();
                    break;
                case 2:
                    higieneGatos();
                    break;
            }
        }

        private void btnRoedor_Clicked(object sender, EventArgs e)
        {
            reiniciarIconos();
            btnRoedor.Source = "RodentIcon.png";
            btnRoedor.IsEnabled = false;
            switch (Piqueador.SelectedIndex)
            {
                case 0:
                    dietaRoedores();
                    break;
                case 1:
                    ejercicioRoedores();
                    break;
                case 2:
                    higieneRoedores();
                    break;
            }
        }

        private void reiniciarIconos()
        {
            slContenido.Children.Clear();

            btnPerro.Source = "DogIcon2.png";
            btnPerro.IsEnabled = true;

            btnRoedor.Source = "RodentIcon2.png";
            btnRoedor.IsEnabled = true;

            btnGato.Source = "CatIcon2.png";
            btnGato.IsEnabled = true;
        }
    }
}