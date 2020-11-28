using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace ProyectoFinal.Clases
{
    public class UserManager
    {
        const string URL = "http://134.209.220.83/proyecto/";
        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;

        }

        public async Task<IEnumerable<User>> userLogin(string user_name,string password)
        {
            HttpClient cliente = getClient();
            
            var result = await cliente.GetAsync(URL+"login.php?user_name="+ user_name + "&password="+password);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
                
            }
            return Enumerable.Empty<User>(); 
        }

        public async Task<IEnumerable<PetDataAll>> listarMascotas()
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "getPetUser.php");
            
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<PetDataAll>>(content);
            }
            return Enumerable.Empty<PetDataAll>();
            
        }

    }
}
