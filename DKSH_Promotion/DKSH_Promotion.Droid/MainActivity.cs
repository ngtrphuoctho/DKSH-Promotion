using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;

namespace DKSH_Promotion.Droid
{
    [Activity(Label = "DKSH", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            this.ActionBar.SetIcon(Android.Resource.Color.Transparent);
            //StartService(new Intent(this, typeof(ServicePromotion)));
        }
    }
}
