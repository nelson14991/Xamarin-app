using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jarvis
{
    class WebServices
    {
        HttpClient client;

       

        public WebServices(User user)
        {
            string authData = string.Format("{0}:{1}", user.Username, user.Password);
            string authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }
        public class AuthenticationResponse{
            public bool authentication;
			public string userRole;
        }
        public async Task<bool> AuthenticateAsync()
        {
            var uri = new Uri(Constants.url);

            try
            {
                HttpContent content1 = new StringContent(String.Empty);
                var response = await client.PostAsync(uri,content1);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var authenticationResponse = new AuthenticationResponse();
                    authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(content);
					Application.Current.Properties["userRole"] = authenticationResponse.userRole; 
					await Application.Current.SavePropertiesAsync();
                    return authenticationResponse.authentication;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                return false;
            }
            return false;
        }
    }
}
