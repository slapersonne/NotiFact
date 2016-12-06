using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiFact.Models
{
    public class NotificationMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRead { get; set; }
        public int Severity { get; set; }
        public string Type { get; set; }

        public NotificationMessage() { }                
    }
}
