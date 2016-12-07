using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NotiFact
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			BindingContext = new LoginViewModel(Navigation);
			InitializeComponent();
		}
	}
}
