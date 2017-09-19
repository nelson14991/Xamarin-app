using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Jarvis
{
    public partial class PanelPage : MasterDetailPage
    {
		User _user;
        public PanelPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += OnItemSelected;
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MasterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
