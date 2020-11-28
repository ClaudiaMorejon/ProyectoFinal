using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Vistas_CodeBehind
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpadatePet : ContentPage
    {
        public UpadatePet(string id_user,string id_pet)
        {
            InitializeComponent();
        }
    }
}