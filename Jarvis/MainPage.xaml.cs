using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Jarvis
{
    public partial class MainPage : ContentPage
    {
		User _user = new User();
        public MainPage()
        {
            InitializeComponent();
			//this._user = App.user;

        }
        public MainPage(User user)
        {
            InitializeComponent();
			this._user = user;
        }
        async void OnScanButtonClicked(object sender, EventArgs e)
        {
            string qrAuthenticationResponse ="";

            var scannedData = await DependencyService.Get<IQrCodeScanningService>().ScanAsync();
            if (scannedData != "Canceled") { 
                qrAuthenticationResponse = await QRCodeAuthenticate(scannedData);
            }
            await DisplayAlert("Scanned Information", qrAuthenticationResponse, "Close");
            
        }
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
        private async Task<string> QRCodeAuthenticate(string qrhash)
        {
            try
            {
                String url = "http://jarviscentral.com/QRCode/QRAuthenticate?QRHash=" + qrhash +"&Username="+this._user.Username;

                HttpClient client = new HttpClient() ;

               
                    HttpContent content1 = new StringContent(String.Empty);
                    var response = await client.PostAsync(url, content1);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();                        
                        return content;
                    }
                else
                {
                    return "Failed";
                }
                
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
