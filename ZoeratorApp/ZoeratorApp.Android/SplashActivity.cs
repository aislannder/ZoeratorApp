using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace ZoeratorApp.Droid
{
    [Activity(Label = "Zoerator", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.StartActivity(typeof(MainActivity));
        }
    }
}