﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Vistas_CodeBehind
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDetail : ContentPage
    {
        public PetDetail(int id_user, int id_pet)
        {
            InitializeComponent();
        }



    }
}