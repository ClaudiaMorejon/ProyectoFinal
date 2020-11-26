using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ProyectoFinal.Clases;
using ProyectoFinal.Utils;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;


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
                parametros.Add("nombre", Nombre.Text);
                parametros.Add("apellido", Apellido.Text);
                parametros.Add("cedula", Cedula.Text);
                parametros.Add("celular", Celular.Text );
                parametros.Add("convencional", Convencional.Text );
                parametros.Add("direccion", Direccion.Text);
                parametros.Add("ciudad", Ciudad.Text );
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

        private async void Btnfoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No soporta fotos", ": (Permission is not granted.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync
                (new Plugin.Media.Abstractions.PickMediaOptions()
                {
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