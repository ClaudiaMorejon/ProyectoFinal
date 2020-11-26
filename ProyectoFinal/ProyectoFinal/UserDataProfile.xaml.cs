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


namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDataProfile : ContentPage
    {
        public UserDataProfile()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            try
            {

                WebClient UserProfile = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idPerson", idPerson.Text);
                parametros.Add("idUser", idUser.Text);
                parametros.Add("nombre", Nombre.Text);
                parametros.Add("apellido", Apellido.Text);
                parametros.Add("cedula", Cedula.Text);
                parametros.Add("celular", Celular.Text );
                parametros.Add("convencional", Convencional.Text );
                parametros.Add("direccion", Direccion.Text);
                parametros.Add("ciudad", Ciudad.Text );
                parametros.Add("imagen", Foto.Text);
                parametros.Add("genero", Genero.Text);

                UserProfile.UploadValues("http://134.209.220.83/proyecto/", "Post", parametros);
                await DisplayAlert("Alerta", "Datos Ingresados", "Ok");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", "ERROR" + ex.Message, "Ok");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Login());

        }
    }
}