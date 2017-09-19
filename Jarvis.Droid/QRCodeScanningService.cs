using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Jarvis.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(QrCodeScanningService))]
namespace Jarvis.Droid
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        
        
        async Task<string> IQrCodeScanningService.ScanAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            try { 

            var scanResults = await scanner.Scan();
                if (scanResults != null)
                    return scanResults.Text;
                else
                    return "Canceled";
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        
       
}
}