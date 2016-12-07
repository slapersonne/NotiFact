using System;
using NotiFact.Models;
using Xamarin.Forms;

namespace NotiFact
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(NotificationMessage notifMessage)
        {
			BindingContext = new NotificationViewModel(Navigation, notifMessage);
            InitializeComponent();            
        }
    }
}
