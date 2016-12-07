using NotiFact.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotiFact.Database
{
    public class DatabaseService
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public DatabaseService()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<NotificationMessage>();
        }

        public IEnumerable<NotificationMessage> GetAllNotificationMessages()
        {
            return (from i in database.Table<NotificationMessage>() select i).ToList();
        }

        public void AddNewNotificationMessage(NotificationMessage newNotification)
        {
            database.Insert(newNotification);
        }
    }
}
