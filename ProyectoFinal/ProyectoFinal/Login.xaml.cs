using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.Clases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private  async void btnRegistrar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new User());

        }
    }
}