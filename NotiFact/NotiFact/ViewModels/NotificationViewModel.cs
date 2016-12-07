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
        public Command TreatCommand { get; protected set; }

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
                IsDone = false,
                Severity = 2,
                Type = NotificationType.Maintenance
            };

            ReturnCommand = new Command(ExecuteReturn);
            AcknowledgeCommand = new Command(ExecuteAcknowledge, CanAcknowledge);
            TreatCommand = new Command(ExecuteTreat, CanTreat);
        }

        private bool CanTreat(object arg)
        {
            return !Notification.IsDone;
        }

        private void ExecuteTreat(object obj)
        {
            Notification.IsRead = true;
            Notification.IsDone = true;
            OnPropertyChanged("Notification");
            OnPropertyChanged("Notification.IsRead");
            OnPropertyChanged("Notification.IsDone");
            AcknowledgeCommand.ChangeCanExecute();
            TreatCommand.ChangeCanExecute();
        }

        private bool CanAcknowledge(object arg)
        {
            return !Notification.IsRead;
        }

        private void ExecuteAcknowledge(object obj)
        {
            Notification.IsRead = true;
            OnPropertyChanged("Notification");

            OnPropertyChanged("Notification.IsRead");
            OnPropertyChanged("Notification.IsDone");
            AcknowledgeCommand.ChangeCanExecute();
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
