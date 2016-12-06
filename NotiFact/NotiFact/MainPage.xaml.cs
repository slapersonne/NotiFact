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
            InitializeComponent();

            Notifications = new List<string> { "Notif1", "Notif2", "Notif3" };
        }

        public List<string> Notifications { get; set; }
    }
}
