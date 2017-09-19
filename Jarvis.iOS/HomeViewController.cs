using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using MonoTouch.Dialog;

namespace Jarvis.iOS
{
    public partial class HomeViewController : DialogViewController
    {
        UIWindow window;
        UINavigationController navController;
        HomeViewController homeViewController;
        public HomeViewController() : base(UITableViewStyle.Grouped, null)
        {
            Root = new RootElement("HomeViewController") {
                new Section ("First Section"){
                    new StringElement ("Hello", () => {
                        new UIAlertView ("Hola", "Thanks for tapping!", null, "Continue").Show ();
                    }),
                    new EntryElement ("Name", "Enter your name", String.Empty)
                },
                new Section ("Second Section"){
                },
            };
        }
    }
}