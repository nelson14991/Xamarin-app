
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Jarvis
{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
		public static User user{ get; set;}

        public App()
        {
			MainPage = new NavigationPage(new LoginPage());

        }


        protected override void OnStart()
        {
            // Handle when your app starts
			if(Application.Current.Properties.ContainsKey("username") && Application.Current.Properties.ContainsKey("password")){
				user = new User ();
				user.Username = Application.Current.Properties ["username"] as string;
				user.Password = Application.Current.Properties ["password"] as string; 
				if(Application.Current.Properties.ContainsKey("userRole")){
					if(Application.Current.Properties["userRole"].ToString().Equals("admin")){
						MainPage = new NavigationPage (new MainPage(user));
					}
					else{
						MainPage = new NavigationPage (new GenerateQRPage());
					}	
				}
			}

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
			Application.Current.SavePropertiesAsync();

        }

        protected override void OnResume()
        {
            // Handle when your app resumes
			if(Application.Current.Properties.ContainsKey("username") && Application.Current.Properties.ContainsKey("password")){
				user = new User ();
				user.Username = Application.Current.Properties ["username"] as string;
				user.Password = Application.Current.Properties ["password"] as string; 
				if(Application.Current.Properties.ContainsKey("userRole")){
					if(Application.Current.Properties["userRole"].ToString().Equals("admin")){
						MainPage = new NavigationPage (new MainPage(user));
					}
					else{
						MainPage = new NavigationPage (new GenerateQRPage());
					}	
				}
			}
        }
    }
}
