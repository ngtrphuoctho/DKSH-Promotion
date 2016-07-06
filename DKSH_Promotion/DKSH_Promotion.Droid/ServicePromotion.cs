using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using DKSH_Promotion.Helper;
using System.Threading.Tasks;

namespace DKSH_Promotion.Droid
{
    [Service]
    class ServicePromotion : Service
    {

        static readonly string TAG = "X:" + typeof(ServicePromotion).Name;
        static readonly int TimerWait = 3000;
        //private static int BtnClickNotification = 1000;
        Timer _timer;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            ApiHelper api = new ApiHelper();
            Task.Run(() => {
                _timer = new Timer(async o =>
                {
                    Log.Debug(TAG, "Hello from SimpleService. {0}", DateTime.UtcNow);
                    bool update = await api.insertDataFromAPI();
                    if (update) { }
                },
                                  null,
                                  0,
                                  TimerWait);
            });

            return StartCommandResult.Sticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            // This example isn't of a bound service, so we just return NULL.
            return null;
        }

        //private void BroadcastStarted()
        //{
        //    Intent BroadcastIntent = new Intent(this, typeof(MainActivity.Receiver));
        //    BroadcastIntent.PutExtra("update", true);
        //    SendBroadcast(BroadcastIntent);
        //}

        public override void OnDestroy()
        {
            base.OnDestroy();

            _timer.Dispose();
            _timer = null;

            // Log.Debug(TAG, "SimpleService destroyed at {0}.", DateTime.UtcNow);
        }
    }
}