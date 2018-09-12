using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace CheckBox.Droid
{
	[Activity(
		 Label = "CheckBox",
		 Theme = "@style/Theme.Splash",
		 NoHistory = true,
		 MainLauncher = true,
		 ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			InvokeMainActivity();
		}

		private void InvokeMainActivity()
		{
			StartActivity(new Intent(this, typeof(MainActivity)));
		}
	}
}
