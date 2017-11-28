using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ZoeratorApp
{
    public partial class MainPage : MasterDetailPage
    {
		public MainPage()
		{
			InitializeComponent();
            masterPage.MasterMenuList.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem is Pages.MasterPageItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.MasterMenuList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
