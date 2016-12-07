using System;
using Xamarin.Forms;

namespace NotiFact
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            BindingContext = new NotificationViewModel(Navigation);
            InitializeComponent();            
        }
    }
}
