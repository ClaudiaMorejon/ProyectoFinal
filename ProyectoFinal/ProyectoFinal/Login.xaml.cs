using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ProyectoFinal.Clases;
using ProyectoFinal.Utils;
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
                UserData userData = new UserData();
                var result1 = await userData.getUserData(Convert.ToInt32(Settings.IdUserLogged));
                UserManager manager = new UserManager();
                var result = await manager.userLogin(txtUsuario.Text.ToString(),txtClave.Text.ToString());
                if (result.Count() > 0)
                {
                    var id_user = result.ElementAt(0).id_user;
                    ProyectoFinal.Utils.Settings.IdUserLogged = id_user.ToString();
                    await DisplayAlert("Bienvenido(a)", result1.ElementAt(0).name, "Aceptar");
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

        private  async void btnRegistrar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new User());

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