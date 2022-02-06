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
                Titulo.Text = "Todo Sobre Ejercicios";
                Parrafo.Text = "Aqui os daremos unos cuantos consejos sobre los diferentes animales con los que trabajamos en esta app";
                Titulo2.Text = "Ejercicios para perros";
                Parrafo2.Text = "Juguetes: busca juguetes que le gusten a tu perro (muchas veces te sorprenderá, lo más simple puede ser lo que más le guste) y lánzaselo hasta que caiga rendido. Ten mucho cuidado con piedras, palos y juguetes, ¡muchos cachorros acaban en el hospital tras haberse comido su juguete favorito!\n\nBusca un amigo: ¿algún otro cachorro cerca? Puede ser buena idea quedar para que jueguen juntos y quemen toda esa energía que tienen. \n\nRecuerda correr, jugar, perseguir… ¡pero sin pasarte! Tu cachorro está en crecimiento y un exceso de ejercicio puede ser perjudicial para sus articulaciones. Espera hasta que haya crecido completamente para practicar ejercicios para perros adultos.";
                Titulo3.Text = "Ejercicios para gatos";
                Parrafo3.Text = "Ejercicio mediante juegos de inteligencia: Existe una gran variedad de juegos de inteligencia muy útiles que podrás utilizar para motivar a tu gato. Algunos expenden golosinas, otros utilizan juguetes o sonidos, dependerá de ti encontrar el que pueda ser más atractivo para él.\n\nEjercicio activo: En este tipo de ejercicio para gatos entras tú ya que debes ser su principal fuente de motivación: \n Debes actuar como un entrenador que intenta lograr el mejor rendimiento de su alumno, siempre sin excedernos.Hazte con juguetes que le motiven y le gusten especialmente, ExpertoAnimal te recomienda aquellos que hacen ruido, sonidos o luces pues logran captar mejor su atención. Como hemos comentado anteriormente deberás dedicar al menos 20 minutos a que persiga dichos juguetes y se ejercite de forma activa.";
                Titulo4.Text = "Ejercicios para roedores";
                Parrafo4.Text = "¿Te gustaría sacar a tu mascota de su casita y darle un paseo de forma segura y sin riesgos? Gracias a una Bola para Hamster tu pequeño peludo podrá explorar el mundo y corretear a sus anchas por tu casa o el jardín. \n\nEn esta pagina encontrarás todo lo relativo a este accesorio; Cómo usarla, consejos de mantenimiento y seguridad, reviews y recomendaciones. Con este complemento, tu hamster tendrá la libertad que se merece y a la vez hará ejercicio. ";
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
                Titulo.Text = "Todo Sobre La Hijiene";
                Parrafo.Text = "";
                Titulo2.Text = "Hijiene para perros";
                Parrafo2.Text = " 1. El baño del perro:\nLa hora del baño es una lotería.Puede que a tu mascota le encante el agua y disfrute del momento, o por el contrario que la aborrezca y se convierta en un suplicio.En cualquier caso, bañar a tu perro es fundamental para proporcionarle una higiene correcta.\n\n2. Oídos sanos y limpios:\nNo hay que olvidar que la higiene de los oídos también es primordial.Es recomendable revisar periódicamente sus oídos. Al menos una vez a la semana especialmente en aquellos perros con orejas grandes, ya que, al no entrar aire a los conductos auditivos, la suciedad se queda incrustada. Si por el contrario tu peludo tiene orejas cortas, con dos veces al mes será suficiente.\n\n3. Operación pelazo: \nMantener el pelaje cuidado es otro de los hábitos en la limpieza e higiene para perros. No sólo lavarlo, sino cortarlo, en especial en los perros de pelo largo y fino o rizado.Los peluqueros caninos son una opción para que tu mascota sea la más guapa, admirada y aseada del parque. Sin olvidar el cepillado diario.\n\n4. Dientes limpios: ¡adiós al mal aliento!\nTampoco podemos olvidarnos de la higiene dental, que no sólo previene el mal aliento, sino que evita también futuras dolencias bucales que pueden derivar en infecciones muy dolorosas. En el mercado existen cepillos de dientes para perros que harán tu tarea más sencilla.Un par de cepillados a la semana evitará posibles problemas dentales.\n\n5. Limpia sus ojitos:\nY, por último, dentro de la limpieza para perros también encontramos sus ojos.Para eliminar las molestas legañas basta con usar gasas humedecidas en suero fisiológico y arrastrarlas suavemente. La limpieza de los ojos previene posibles infecciones como la conjuntivitis.";
                Titulo3.Text = "Hijiene para Gatos";
                Parrafo3.Text = "La bandeja de arena\n\nEs importante que revisemos y limpiemos, al menos una vez al día, la bandeja en la que hacen sus necesidades, siempre dependiendo del tipo de arena que utilicemos, claro. Hay arenas que necesitan ser cambiadas a diario y otras que permiten retirar los desechos sin necesidad de cambiar la bandeja, como la arena aglomerante. Si no lo hacemos, el fuerte olor de la bandeja puede hacer que el gato no quiera hacer allí sus necesidades y las haga en cualquier otro sitio de la casa. En los casos en los que tengáis gatos de pelo largo y para evitar encontrar heces pegadas, os recomendamos que les cortéis de vez en cuando los pelos que rodean el ano.\n\nEl cepillado:\n\n Independientemente de si el pelo de vuestro gato es largo o corto se aconseja que lo cepilléis, por lo menos, una vez a la semana, aunque lo ideal sería hacerlo a diario.Gracias al cepillado evitaréis problemas dermatológicos y además daréis unos momentos de placer a vuestro gato, ya que los felinos adoran ser cepillados. Si vuestro gato tiene acceso al exterior debéis prestar mucha atención a su cepillado, especialmente en épocas como la primavera, durante la muda y la temporada de lluvias. En el caso de los gatos de pelo largo, éste puede compactarse en una masa ideal para acoger parásitos, lo que podría derivar en serios problemas dermatológicos.De ahí radica la importancia de cepillarlo con regularidad.";
                Titulo4.Text = "Hijiene para Roedores";
                Parrafo4.Text = "¿Cómo bañar a un roedor?: \n\nPor lo general los roedores son bastante limpios ya que pasan gran parte del tiempo lamiéndose. Pero en ocasiones, hasta los roedores más limpios pueden necesitar una ayuda extra con su higiene personal. Los baños no tienen que ser muy frecuentes, bastará con un par de veces o tres al año, ya que si lo bañas con mucha frecuencia puedes dañar el pH de la piel, por lo que además es muy importante elegir un champú adecuado y formulado especialmente para ellos.\n\n¿Cómo cepillar a un roedor?:\n\nEl cepillado es muy importante porque, además de conseguir que su pelaje tenga un mejor aspecto, ayuda a que mejore su circulación. El cepillado se hace imprescindible sobre todo en la época de muda. En función del tipo de pelaje que tenga necesitarás un peine con púas o un cepillo, pero con cualquiera de los dos debemos tener mucho cuidado de no tirar de los nudos que pueda tener tu pequeñín. Se debe cepillar a lo largo de todo el cuerpo, teniendo especial cuidado con la barriga ya que es una parte muy sensible y podrías hacerle daño.";
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
            }

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

        }
        private void ejercicioGatos()
        {

        }
        private void ejercicioRoedores()
        {

        }
        private void higienePerros()
        {

        }
        private void higieneGatos()
        {

        }
        private void higieneRoedores()
        {

        }

        private void btnPerro_Clicked(object sender, EventArgs e)
        {
            reiniciarIconos();
            btnPerro.Source = "DogIcon.png";
            btnPerro.IsEnabled = false;
            dietaPerros();
        }

        private void btnGato_Clicked(object sender, EventArgs e)
        {
            reiniciarIconos();
            btnGato.Source = "CatIcon.png";
            btnGato.IsEnabled = false;
            dietaGatos();
        }

        private void btnRoedor_Clicked(object sender, EventArgs e)
        {
            reiniciarIconos();
            btnRoedor.Source = "RodentIcon.png";
            btnRoedor.IsEnabled = false;
            dietaRoedores();
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