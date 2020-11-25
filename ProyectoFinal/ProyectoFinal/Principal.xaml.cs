using Newtonsoft.Json;
using ProyectoFinal.Clases;
using ProyectoFinal.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        UserManager manager = new UserManager();
        public Principal()
        {
            InitializeComponent();
           
            
            
        }

        protected async override void OnAppearing()
        {
            try
            {
                UserManager manager = new UserManager();
                var result = await manager.listarMascotas();
                if (result != null)
                {
                    lstPet.ItemsSource = result;
                }

            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {

            try
            {

            }
            catch (Exception)
            {

            }




        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                UserData userData = new UserData();
                var result = await userData.getUserData(Convert.ToInt32(Settings.IdUserLogged));
                if (result.Count() > 0)
                {
                    await DisplayAlert("Success", result.ElementAt(0).name, "Aceptar", "Cancelar");
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o clave incorrecta", "Aceptar", "Cancelar");
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Alerta", "ERROR: " + e1.Message, "OK");
            }
        }
    }
}