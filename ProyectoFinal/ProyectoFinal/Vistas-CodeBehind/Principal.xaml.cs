using Newtonsoft.Json;
using ProyectoFinal.Clases;
using ProyectoFinal.Utils;
using ProyectoFinal.Vistas_CodeBehind;
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

        private async void btn_RegistrarMascota_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new PetProfile());
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (PetDataAll)e.SelectedItem;
            var id_pet = obj.id_pet.ToString();
            var id_user = obj.id_pet.ToString();
            int PET = Convert.ToInt32(id_pet);
            int ID = Convert.ToInt32(id_user);
            try
            {
                Navigation.PushAsync(new UpadatePet(ID,PET));
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

    
}
