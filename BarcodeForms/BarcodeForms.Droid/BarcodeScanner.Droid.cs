using System;

using Android.App;
using Android.Content;

using Xamarin.Forms;

using BarcodeForms;

[assembly: Dependency(typeof(BarcodeForms.Droid.BarcodeScanner))]

namespace BarcodeForms.Droid
{
    public class BarcodeScanner : IScanner
    {
        // Let's define the API intent strings for the soft scan trigger
		private static String ACTION_SOFTSCANTRIGGER = "com.motorolasolutions.emdk.datawedge.api.ACTION_SOFTSCANTRIGGER";
		private static String EXTRA_PARAM = "com.motorolasolutions.emdk.datawedge.api.EXTRA_PARAMETER";
        private static String DWAPI_TOGGLE_SCANNING = "TOGGLE_SCANNING";
        
        public void Scan()
        {
            var intent = new Intent();
            Activity current = (Activity)Forms.Context;
            intent.SetAction(ACTION_SOFTSCANTRIGGER);
            intent.PutExtra(EXTRA_PARAM, DWAPI_TOGGLE_SCANNING);
            current.SendBroadcast(intent);
        }
    }
}