using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Firebase.Iid;
using Firebase.Messaging;

namespace NotiFact.Droid
{
    [Activity(Label = "NotiFact", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		private const string GcmSenderId = "672494234051";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

		public void RegisterToNotifications()
		{
			Task.Run(() =>
			{
				try
				{
					var instanceID = FirebaseInstanceId.Instance;
					instanceID.DeleteInstanceId();
					var iid1 = instanceID.Token;
					var token = instanceID.GetToken(GcmSenderId, FirebaseMessaging.InstanceIdScope);
					System.Diagnostics.Debug.WriteLine($"Iid1 : {iid1}");
					System.Diagnostics.Debug.WriteLine($"Iid2 : {token}");
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex);
				}
			});
		}
    }
}

