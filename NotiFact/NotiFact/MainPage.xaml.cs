using NotiFact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotiFact
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
			BindingContext = new MainViewModel(Navigation);
            InitializeComponent();

			list.ItemSelected += (sender, e) => {
				Navigation.PushAsync(new DetailsPage());
			};
        }

		protected override void OnAppearing()
		{
			NavigationPage.SetHasBackButton(this, false);
			base.OnAppearing();
		}
    }
}
