using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ProyectoFinal.Clases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserManager manager = new UserManager();
                var result = await manager.userLogin(txtUsuario.Text.ToString(),txtClave.Text.ToString());
                if (result.Count() > 0)
                {
                    var id_user = result.ElementAt(0).id_user;
                    ProyectoFinal.Utils.Settings.IdUserLogged = id_user.ToString();
                    await Navigation.PushAsync(new Principal());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o clave incorrecta", "Aceptar", "Cancelar");
                }
            }
            catch(Exception e1)
            {
                await DisplayAlert("Alerta", "ERROR: " + e1.Message, "OK");
            }
            
        }

        private  void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void btnSeleccionarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No soporta fotos", ": (Permission is not granted.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync
                (new Plugin.Media.Abstractions.PickMediaOptions(){
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return;

            Imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}