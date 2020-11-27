using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoFinal.Clases
{
    public class UserData
    {
        const string URL = "http://134.209.220.83/proyecto/";
        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;

        }

        public async Task<IEnumerable<UserDataProfile>> getUserData(int id_user)
        {
            HttpClient cliente = getClient();

            var result = await cliente.GetAsync(URL + "user_data.php?id_user=" + id_user);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<UserDataProfile>>(content);

            }
            return Enumerable.Empty<UserDataProfile>();
        }

        public async Task<User> setUserData(String user_name, String password)
        {
            HttpClient cliente = getClient();

            var parameters = new Dictionary<string, string> { { "user_name", user_name }, { "password", password } };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await cliente.PostAsync(URL + "post_user.php", encodedContent);
            
            if (response.IsSuccessStatusCode)
            {
                
                string content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<User>(content);

            }
            return null;
        }

        public async Task<UserDataProfile> setUserDataProfile(string id_user, String name, String last_name, String identifier, String cell_phone, String home_phone, String address, String gender)
        {
            HttpClient cliente = getClient();

            var parameters = new Dictionary<string, string> 
            { { "id_user", id_user }, 
                { "name", name },
                { "last_name", last_name },
                { "identifier", identifier },
                { "cell_phone", cell_phone },
                { "home_phone", home_phone },
                { "address", address },
                { "gender", gender } };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await cliente.PostAsync(URL + "post_person.php", encodedContent);

            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserDataProfile>(content);

            }
            return null;
        }

    }
}
