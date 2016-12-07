using NotiFact.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotiFact
{
    public class LoginViewModel : INotifyPropertyChanged
    {
		public Command LoginCommand
		{
			get;
			set;
		}

		public LoginViewModel(INavigation navService)
		{
			LoginCommand = new Command(() => {
			 	navService.PushAsync(new MainPage());
			});
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
