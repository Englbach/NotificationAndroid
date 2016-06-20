using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Content;

namespace NotificationAndroid
{
	[Activity(Label = "NotificationAndroid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += (object sender, System.EventArgs e) =>
			{
				// Instantiate the builder and set notification elements:
				Notification.Builder builder = new Notification.Builder(this)
					.SetContentTitle("Xin chao cac ban!! Hello")
					.SetContentText("Hello World! This is my first notification!")
					.SetSmallIcon(Resource.Drawable.Alarm);
				//The timestamp is set automatically, but you can override this setting by calling the SetWhen method of the notification builder.
				//For example, the following code example sets the timestamp to the current time:
				builder.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis());

				/*
				 * This call to SetDefaults will cause the device to play a sound when the notification is published.
				 * If you want the device to vibrate rather than play a sound, you can pass NotificationDefaults.Vibrate to SetDefaults.
				 * If you want the device to play a sound and vibrate the device, you can pass both flags to SetDefaults:
				 */
				builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

				// Build the notification:
				Notification notification = builder.Build();

				// Get the notification manager:
				NotificationManager notificationManager =
					GetSystemService(Context.NotificationService) as NotificationManager;

				// Publish the notification:
				const int notificationId = 0;
				notificationManager.Notify(notificationId, notification);
			};;
		}
	}
}


