using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Jarvis
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try { 
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = await AuthenticateUser(user);
            if (isValid == true)
            {
                	App.IsUserLoggedIn = true;
					Application.Current.Properties["username"] = user.Username;
					Application.Current.Properties["password"] = user.Password;

					await Application.Current.SavePropertiesAsync();
				
				if(Application.Current.Properties["userRole"].ToString().Equals("admin")){
					Navigation.InsertPageBefore(new MainPage(user), this);
				}
				else{
					Navigation.InsertPageBefore(new GenerateQRPage(), this);
				}
				//App.user = user;
				//Navigation.InsertPageBefore(new MainPage(user), this);
                await Navigation.PopAsync();
            }
            else {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        public async Task<bool> AuthenticateUser(User user)
        {
            var webservice = new WebServices(user);
            var result = await webservice.AuthenticateAsync();
            //var result = await webservice.AuthenticateAsync();
            // return true;
            return result;
        }
    }
}
