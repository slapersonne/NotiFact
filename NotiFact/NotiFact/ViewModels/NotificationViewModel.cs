using NotiFact.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiFact
{
    public class NotificationViewModel : INotifyPropertyChanged
    {
        private NotificationMessage _notification;

        public NotificationViewModel()
        {
            Notification = new NotificationMessage
            {
                Title = "Message Title",
                Message = "bla bla bla très important avec des caractères spéciaux et des \n qui vont bien et aussi des " + Environment.NewLine + "pour tester.",
                Author = "FX12226",
                CreationDate = DateTime.Now,
                IsRead = false,
                Severity = 2,
                Type = "Securité"
            };
        }

        public NotificationMessage Notification
        {
            get
            {
                return _notification;
            }
            set
            {
                if (_notification != value)
                {
                    _notification = value;
                    OnPropertyChanged("Notification");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
