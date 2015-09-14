using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Widget;

using Symbol.XamarinEMDK;

namespace symbol.xamarinemdk.profiledatacapturesample1
{
    class ProcessProfileSetXMLTask : AsyncTask<MainActivity, Java.Lang.Void, EMDKResults>
    {
        private TextView statusTextView = null;

        protected override EMDKResults RunInBackground(params MainActivity[] @params)
        {
            ProfileManager profileManager = @params[0].profileManager;
            string profileName = @params[0].profileName;
            string[] modifyData = @params[0].modifyData;
            statusTextView = @params[0].statusTextView;

            // Call processPrfoile with profile name, 'Set' flag and modify data to update the profile
            return profileManager.ProcessProfile(profileName, ProfileManager.PROFILE_FLAG.Set, modifyData);
        }

        protected override void OnPostExecute(EMDKResults results)
        {

            base.OnPostExecute(results);

            String resultString;

            //Check the return status of processProfile
            resultString = results.StatusCode == EMDKResults.STATUS_CODE.Success ? "Set profile success." : "Set profile failed.";

            if (statusTextView != null)
            {
                statusTextView.Text = resultString;
            }
        }
    }
}
