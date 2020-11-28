using ProyectoFinal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Vistas_CodeBehind
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpadatePet : ContentPage
    {
        int id_pet = 0;
        public UpadatePet(int id_user,int id_pet)
        {
            InitializeComponent();
            this.id_pet = id_pet;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient PetProfiles = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                string status = "1";

                parametros.Add("id_pet", id_pet.ToString());
                parametros.Add("pet_name", txtNombreMas.Text);
                parametros.Add("age", txtEdadMas.Text);
                parametros.Add("gender", txtGeneroMas.Text);
                parametros.Add("description", txtDescripcion.Text);
                parametros.Add("size", txtTamanioMas.Text);
                parametros.Add("breed", txtRaz.Text);
                parametros.Add("color", txtColor.Text);
                parametros.Add("status", status);

                PetProfiles.UploadValues("http://134.209.220.83/proyecto/putPet.php", "Put", parametros);

                await DisplayAlert("Alerta", "Datos Actualizados", "Ok");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", "ERROR" + ex.Message, "Ok");
            }
        }
    }
}