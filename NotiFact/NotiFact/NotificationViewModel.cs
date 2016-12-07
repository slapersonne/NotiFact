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
    public class NotificationViewModel : INotifyPropertyChanged
    {
        private NotificationMessage _notification;
        private INavigation _nav;

        public Command ReturnCommand { get; protected set; }
        public Command AcknowledgeCommand { get; protected set; }

        public NotificationViewModel(INavigation nav)
        {
            _nav = nav;
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

            ReturnCommand = new Command(ExecuteReturn);
            AcknowledgeCommand = new Command(ExecuteAcknowledge, CanAcknowledge);
        }

        private bool CanAcknowledge(object arg)
        {
            return !Notification.IsRead;
        }

        private void ExecuteAcknowledge(object obj)
        {
            Notification.IsRead = true;
            OnPropertyChanged("Notification");
            AcknowledgeCommand.ChangeCanExecute();
            ExecuteReturn(obj);
        }

        private void ExecuteReturn(object obj)
        {
            _nav.PopAsync();
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
