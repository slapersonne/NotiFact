using NotiFact.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NotiFact
{
    public class MainViewModel : INotifyPropertyChanged
    {
		#region Commands
		public Command LoginCommand { get; set; }
		#endregion

		#region Properties
		private IEnumerable<NotificationMessage> _messagesList;

		public ObservableCollection<NotificationMessage> MessagesList
		{
			get
			{
				return new ObservableCollection<NotificationMessage>(_messagesList);
			}
			set
			{
				if (_messagesList != value)
				{
					_messagesList = value;
					OnPropertyChanged("MessagesList");
				}
			}
		}
		#endregion


		public MainViewModel(INavigation navService)
		{
			LoginCommand = new Command(() => {
			 	navService.PushAsync(new MainPage());
			});
			_messagesList = new List<NotificationMessage> {
				new NotificationMessage{ Title="Maintenance", Severity=2, Message="Vous devez faire la maintenance"},
				new NotificationMessage{ Title="Intervention", Severity=1, Message="Trappe à réparer"},
				new NotificationMessage{ Title="Avertissement", Severity=3, Message="Vanne hydraulique à contrôler"},
				new NotificationMessage{ Title="Maintenance", Severity=3, Message="Vous devez faire la maintenance"},
				new NotificationMessage{ Title="Intervention", Severity=0, Message="Trappe à réparer"},
				new NotificationMessage{ Title="Avertissement", Severity=1, Message="Vanne hydraulique à contrôler"},
				new NotificationMessage{ Title="Maintenance", Severity=1, Message="Vous devez faire la maintenance"},
				new NotificationMessage{ Title="Intervention", Severity=3, Message="Trappe à réparer"},
				new NotificationMessage{ Title="Avertissement", Severity=2, Message="Vanne hydraulique à contrôler"},
				new NotificationMessage{ Title="Maintenance", Severity=0, Message="Vous devez faire la maintenance"},
				new NotificationMessage{ Title="Intervention", Severity=2, Message="Trappe à réparer"},
				new NotificationMessage{ Title="Avertissement", Severity=1, Message="Vanne hydraulique à contrôler"}
			};
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
