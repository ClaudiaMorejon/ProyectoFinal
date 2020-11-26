﻿using Newtonsoft.Json;
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
    public partial class User : ContentPage
    {
       public User()
        {
            InitializeComponent();
        }

        

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            try
            {
                WebClient UserProfile = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                
                parametros.Add("user_name", Usuario.Text);
                parametros.Add("password", Password.Text);

                UserProfile.UploadValues("http://134.209.220.83/proyecto/postuser1.php", "POST", parametros);
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

        private async void perfil_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new UserDataProfile());

        }
    }
}