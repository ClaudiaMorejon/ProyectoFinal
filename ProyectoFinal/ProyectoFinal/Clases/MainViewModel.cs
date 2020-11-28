using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ProyectoFinal.Clases
{
    public class MainViewModel
    {
        public ObservableCollection<PetDataAll> PetDataAll { get; set; }
        UserManager userManager = new UserManager();

        public MainViewModel()
        {
            getList();   
        }
        public async void getList()
        {
            var result = await userManager.listarMascotas();
        if (result != null)
            {
                PetDataAll = new ObservableCollection<PetDataAll>(result.Cast<PetDataAll>());
            }
        }
    }

    


}
