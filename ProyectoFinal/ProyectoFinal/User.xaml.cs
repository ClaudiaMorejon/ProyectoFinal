using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.Clases;
using ProyectoFinal.Utils;

namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class User : ContentPage
    {
       public User()
        {
            InitializeComponent();
        }


        /*
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            try
            {
                WebClient UserProfile = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                
                parametros.Add("user_name", Usuario.Text);
                parametros.Add("password", Password.Text);

                UserProfile.UploadValues("http://134.209.220.83/proyecto/postuser1.php", "POST", parametros);

                var parametrosPerfil = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("user_name", Usuario.Text);
                parametros.Add("password", Password.Text);

                
                await DisplayAlert("Alerta", "Datos Ingresados", "Ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR" + ex.Message, "Ok");
            }
        
        }*/

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserData userData = new UserData();

                String user_name = txtUsuario.Text.ToString();
                String password = txtClave.Text.ToString();

                var response = await userData.setUserData(user_name,password);

                String id_user = response.id_user.ToString();

                String name = txtNombre.Text.ToString();
                String last_name = txtApellido.Text.ToString();
                String identifier = txtCedula.Text.ToString();
                String cell_phone = txtCelular.Text.ToString();
                String home_phone = txtConvencional.Text.ToString();
                String address = txtDireccion.Text.ToString();
                String gender = txtGenero.Text.ToString();

                var response1 = await userData.setUserDataProfile(id_user, name, last_name, identifier, cell_phone, home_phone, address, gender);

                await DisplayAlert("Prueba", response1.identifier.ToString() , "Aceptar");
            }
            catch (Exception e1)
            {
                await DisplayAlert("Alerta", "ERROR: " + e1.Message, "OK");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Login());

        }

        private async void perfil_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new UserDataProfile());

        }
    }
}