using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Jarvis
{
    public partial class MasterPage : ContentPage
    {

        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Home",
                IconSource = "contacts.png",
				TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Scan QR",
                IconSource = "todo.png",
				TargetType = typeof(MainPage)
            });
            

            listView.ItemsSource = masterPageItems;
        }

    }
}
