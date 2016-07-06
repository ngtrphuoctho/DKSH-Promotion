using System;
using Xamarin.Forms;
using DKSH_Promotion.Android;
using DKSH_Promotion.PhoneNumberService;
using Android.Telephony;
using Android.Content;

[assembly: Dependency(typeof(GetPhoneNumber_Android))]

namespace DKSH_Promotion.Android
{
    public class GetPhoneNumber_Android: ITGetPhoneNumber    {
        public GetPhoneNumber_Android() { }
    
        public String getPhoneNumber()
        {
            var c = Forms.Context;
            TelephonyManager mTelephonyMgr = (TelephonyManager)c.GetSystemService(Context.TelephonyService);

            return mTelephonyMgr.Line1Number;

        }


    }
}   
