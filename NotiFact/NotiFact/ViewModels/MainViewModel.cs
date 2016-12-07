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
using NotiFact.Database;

namespace NotiFact
{
    public class MainViewModel : INotifyPropertyChanged
    {
		#region Commands
		public Command LoginCommand { get; set; }
		#endregion

		#region Properties
		private IEnumerable<NotificationMessage> _messagesList;
        static DatabaseService _database;

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

        public static DatabaseService Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DatabaseService();
                }
                return _database;
            }
        }
        #endregion


        public MainViewModel(INavigation navService)
		{
			LoginCommand = new Command(() => {
			 	navService.PushAsync(new MainPage());
			});

            _messagesList = new List<NotificationMessage>();
            _messagesList = Database.GetAllNotificationMessages().ToList();
            /*
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
			};*/
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InitData()
        {
            var messagesList = new List<NotificationMessage>
            {
                new NotificationMessage{
                    Title ="Mise à Jour SRVP Urgente",
                    Message ="Installation de la version 5.1.4.6 de SRVP Urgente à faire. Cette version corrige TOUS les problèmes existant dans SRVP",
                    Author = "FX12357",
                    CreationDate = DateTime.Now.AddHours(-5),
                    IsRead = false,
                    Severity = 3,
                    Type = NotificationType.Maintenance
                },
                new NotificationMessage
                {
                    Title ="Problème clusters",
                    Message ="Des Problèmes ont été détectés sur les dernier cluster installés",
                    Author = "FX12357",
                    CreationDate = DateTime.Now.AddHours(-5),
                    IsRead = false,
                    Severity = 1,
                    Type = NotificationType.Security
                }
            };

            foreach (var message in messagesList)
            {
                Database.AddNewNotificationMessage(message);

            }
        }
    }

}
