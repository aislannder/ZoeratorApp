using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ZoeratorApp.Pages
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }

	public partial class MasterPage : ContentPage
	{
        public ListView MasterMenuList
        {
            get
            {
                return MenuListView;
            }
        }

        public MasterPage ()
		{
			InitializeComponent ();

            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Home",
                    TargetType = typeof(HomePage)
                },

                new MasterPageItem
                {
                    Title = "Contato",
                    TargetType = typeof(ContactUsPage)
                }
            };

            MenuListView.ItemsSource = masterPageItems;
        }
	}
}