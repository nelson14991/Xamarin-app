using Jarvis.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(QRCodeScanningService))]
namespace Jarvis.iOS
{
    class QRCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            try
            { 
            var scanResults = await scanner.Scan();
                if (scanResults != null)
                    return scanResults.Text;
                else
                    return "Canceled";
            throw new NotImplementedException();
            }
            catch (Exception ex)
            {                
                return ex.Message.ToString();
            }
        }
    }
}
