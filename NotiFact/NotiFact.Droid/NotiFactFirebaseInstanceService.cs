using System;
using Android.App;
using Firebase.Iid;

namespace NotiFact.Droid
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
	class NotiFactFirebaseInstanceService : FirebaseInstanceIdService
	{
		public override void OnTokenRefresh()
		{
			System.Diagnostics.Debug.WriteLine($"FirebaseInstanceIdService OnTokenRefresh");
			var token = FirebaseInstanceId.Instance.Token;
			System.Diagnostics.Debug.WriteLine($"new token : {token}");
		}
	}
}
