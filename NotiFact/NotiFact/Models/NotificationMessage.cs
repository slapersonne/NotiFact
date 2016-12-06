using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiFact.Models
{
    class NotificationMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRead { get; set; }
        public int Severity { get; set; }

        public NotificationMessage(string title, string message, string author,DateTime creationDate, bool isRead)
        {
            Title = title;
            Message = message;
            Author = author;
            creationDate = CreationDate;
            IsRead = IsRead;
        }

        public NotificationMessage(string title, string message, string author, DateTime creationDate, bool isRead, int severity)
        {
            Title = title;
            Message = message;
            Author = author;
            creationDate = CreationDate;
            IsRead = IsRead;
            Severity = severity;
        }

    }
}
