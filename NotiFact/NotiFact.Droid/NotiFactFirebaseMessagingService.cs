using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Firebase.Messaging;

namespace NotiFact.Droid
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class NotiFactFirebaseMessagingService : FirebaseMessagingService
	{
		public override void OnMessageReceived(RemoteMessage message)
		{
			var notification = message.GetNotification();
			if (notification != null)
			{
				System.Diagnostics.Debug.WriteLine($"FirebaseMessagingService - From {message.From}");
				this.SendNotification(notification);
			}
		}

		void SendNotification(RemoteMessage.Notification notification)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);

			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

			var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
			var notificationBuilder = new NotificationCompat.Builder(this)
															.SetContentTitle(notification.Title)
			                                                .SetSmallIcon(Resource.Drawable.maintenance)
															.SetContentText(notification.Body)
															.SetAutoCancel(true)
															.SetSound(defaultSoundUri)
															.SetContentIntent(pendingIntent);

			var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
			notificationManager.Notify(0, notificationBuilder.Build());
		}
	}
}
