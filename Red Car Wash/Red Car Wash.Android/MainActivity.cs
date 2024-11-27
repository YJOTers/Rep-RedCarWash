using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Acr.UserDialogs;
using Xamarin.Forms;
using Android.Gms.Ads;

namespace Red_Car_Wash.Droid
{
    [Activity(Label = "Red_Car_Wash", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MobileAds.Initialize(ApplicationContext);
            Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}