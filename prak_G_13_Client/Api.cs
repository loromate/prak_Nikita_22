using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace prak_G_13_Client
{
    public class Error {
        public int Error_id { get; set; }
        public string Error_name { get; set; }
        public int Dop_time { get; set; }
        public int Error_type_id { get; set; }
    }
    public class user {
        public int User_id { get; set; }
        public string Email { get; set; }
         public string FIO { get; set; }
        public string Password { get; set; }
    }
    public class Api
    {
        public static user itus;
        public static List<user> lstus = new List<user>();
        public static List<user> getuser()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.56.1:60158/");
            HttpResponseMessage response = client.GetAsync("api/User/").Result;
            List<user> lstvisit = new List<user>();
            if (response.IsSuccessStatusCode)
            {
                var context = response.Content.ReadAsAsync < List <user>>().Result;
                foreach (var item in context)
                {
                    lstvisit.Add(item);
                }
            }
            if (lstus.Count == 0)
            {
                lstus.AddRange(lstvisit);
                return null;
            }
            else
            {
                if (lstus.Count != lstvisit.Count)
                {
                    lstus.Clear();
                    lstus.AddRange(lstvisit);
                    return lstvisit;
                }
                else
                {
                    return null;
                }
            }
        }
        public static void posterror(Error er) {
            HttpClient cl = new HttpClient();
            cl.BaseAddress = new Uri("http://192.168.56.1:60158/");
            cl.DefaultRequestHeaders.Accept.Clear();
            cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = cl.PostAsync("api/Error/",new StringContent(JsonSerializer.Serialize(er))).Result;
        }
    }
}
