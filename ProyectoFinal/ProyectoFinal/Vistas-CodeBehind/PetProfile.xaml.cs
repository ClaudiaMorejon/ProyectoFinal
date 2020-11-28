using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.Utils;

namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetProfile : ContentPage
    {
        public PetProfile()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient PetProfiles = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                string status = "1";

                parametros.Add("id_user", Settings.IdUserLogged);
                parametros.Add("pet_name", txtNombreMas.Text);
                parametros.Add("age", txtEdadMas.Text);
                parametros.Add("gender", txtGeneroMas.Text);
                parametros.Add("description", txtDescripcion.Text);
                parametros.Add("size", txtTamanioMas.Text);
                parametros.Add("breed", txtRaz.Text);
                parametros.Add("color", txtColor.Text);
                parametros.Add("status", status);

                PetProfiles.UploadValues("http://134.209.220.83/proyecto/setPet.php", "Post", parametros);

                await DisplayAlert("Alerta", "Datos Ingresados", "Ok");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", "ERROR" + ex.Message, "Ok");
            }
        }
    }
}