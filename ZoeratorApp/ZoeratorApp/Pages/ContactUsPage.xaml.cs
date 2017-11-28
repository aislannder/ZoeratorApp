using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZoeratorApp.Common;

namespace ZoeratorApp.Pages
{
	public partial class ContactUsPage : ContentPage
	{
		public ContactUsPage ()
		{
			InitializeComponent ();
		}

        public void Facebook_clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Constants.FacebookUrl));
        }
        public void Youtube_clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Constants.YoutubeUrl));
        }
        public void Twitter_clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Constants.TwitterUrl));
        }
        public void Phone_clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("tel:+962799892728"));
        }
    }
}