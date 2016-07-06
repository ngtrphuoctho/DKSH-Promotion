using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DKSH_Promotion.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted})]
    class BootCompletedBroadcastMessageReceiver: BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("\r\nreceived boot broadcast.");
            Intent startIntent = new Intent(context, typeof(ServicePromotion));
            context.StartService(startIntent);
        }
    }
}