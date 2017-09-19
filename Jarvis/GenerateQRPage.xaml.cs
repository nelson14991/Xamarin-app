using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FFImageLoading.Forms;
using FFImageLoading.Cache;

namespace Jarvis
{
	public partial class GenerateQRPage : ContentPage
	{
		private User _user = new User();
		private Uri uri;
		public GenerateQRPage ()
		{
			Device.StartTimer (TimeSpan.FromSeconds(30),Refresh);
			InitializeComponent ();
			this._user.Username = Application.Current.Properties ["username"] as string;
			this._user.Password = Application.Current.Properties ["password"] as string;

			if (this._user.Username != null) {
				//this.uri = new Uri ("http://jarviscentral.com/Qrcode/GetBarcodeImage?userId=" + _user.Username);
				//var qrImage = new Image { Aspect = Aspect.AspectFit };
				//	qrImage.Source = ImageSource.FromUri(this.uri);
				this.uri = new Uri("http://jarviscentral.com/Qrcode/GetBarcodeImage?userName=" + _user.Username);

				var cachedImage = new CachedImage () {
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					WidthRequest = 300,
					HeightRequest = 300,
					CacheDuration = TimeSpan.FromMilliseconds (30),
					DownsampleToViewSize = true,
					RetryCount = 0,
					RetryDelay = 250,
					TransparencyEnabled = false,
					Source = uri,
				};
				Content = cachedImage;
			}
		}
		async void OnLogoutButtonClicked(object sender, EventArgs e)
		{
			App.IsUserLoggedIn = false;
			Navigation.InsertPageBefore(new LoginPage(), this);
			await Navigation.PopAsync();
		}
		public bool Refresh(){
			
			Device.BeginInvokeOnMainThread (()=>{
				//GenerateQRPage();
				CachedImage.ClearCache(CacheType.All);
				var cachedImage = new CachedImage () {
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					WidthRequest = 300,
					HeightRequest = 300,
					CacheDuration = TimeSpan.FromMilliseconds (30),
					DownsampleToViewSize = true,
					RetryCount = 0,
					RetryDelay = 250,
					TransparencyEnabled = false,
					Source = uri,
				};
				Content = cachedImage;
			});

					
			return true;
		}
	}
}

