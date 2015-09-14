using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Symbol.XamarinEMDK;
namespace symbol.xamarinemdk.profiledatacapturesample1
{
    [Activity(Name = "symbol.xamarinemdk.profiledatacapturesample1.MainActivity", Label = "ProfileDataCaptureSample1", MainLauncher = true, Icon = "@drawable/icon", WindowSoftInputMode = SoftInput.AdjustPan, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity, EMDKManager.IEMDKListener
    {
        // Declare a variable to store EMDKManager object
        private EMDKManager emdkManager = null;
        // Declare a variable to store ProfileManager object
        internal ProfileManager profileManager = null;

        // Assign the profile name used in EMDKConfig.xml
        internal string profileName = "DataCaptureProfile-1";
        // Pass the modify data for the profile
        internal string[] modifyData = new string[1];

        internal TextView statusTextView = null;
        private CheckBox checkBoxCode128= null;
        private CheckBox checkBoxCode39 = null;
        private CheckBox checkBoxEAN8   = null;
        private CheckBox checkBoxEAN13  = null;
        private CheckBox checkBoxUPCA   = null;
        private CheckBox checkBoxUPCE0  = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            statusTextView  = FindViewById<TextView>(Resource.Id.textViewStatus) as  TextView;
            checkBoxCode128 = FindViewById<CheckBox>(Resource.Id.checkBoxCode128);
            checkBoxCode39  = FindViewById<CheckBox>(Resource.Id.checkBoxCode39);
            checkBoxEAN8    = FindViewById<CheckBox>(Resource.Id.checkBoxEAN8);
            checkBoxEAN13   = FindViewById<CheckBox>(Resource.Id.checkBoxEAN13);
            checkBoxUPCA    = FindViewById<CheckBox>(Resource.Id.checkBoxUPCE);
            checkBoxUPCE0   = FindViewById<CheckBox>(Resource.Id.checkBoxUPCE0);

            // Set listener to the button
            AddSetButtonListener();

            // The EMDKManager object will be created and returned in the callback
            EMDKResults results = EMDKManager.GetEMDKManager(Android.App.Application.Context, this);

            // Check the return status of processProfile
            if (results.StatusCode != EMDKResults.STATUS_CODE.Success)
            {
                // EMDKManager object initialization success
                statusTextView.Text = "EMDKManager object creation failed ...";
            }
            else
            {
                // EMDKManager object initialization failed
                statusTextView.Text = "EMDKManager object creation succeeded ...";
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            // Clean up the objects created by EMDK manager
            if (profileManager != null)
            {
                profileManager = null;
            }

            if (emdkManager != null)
            {
                emdkManager.Release();
                emdkManager = null;
            }
        }

        #region IEMDKListener Members

        public void OnClosed()
        {
            // This callback will be issued when the EMDK closes unexpectedly.

            if (emdkManager != null)
            {
                emdkManager.Release();
                emdkManager = null;
            }

            statusTextView.Text = "EMDK closed unexpectedly! Please close and restart the application.";
       }

        public void OnOpened(EMDKManager emdkManagerInstance)
        {
            // This callback will be issued when the EMDK is ready to use.
            statusTextView.Text = "EMDK open success.";

            this.emdkManager = emdkManagerInstance;

            try
            {
                // Get the ProfileManager object to process the profiles
                profileManager = (ProfileManager)emdkManager.GetInstance(EMDKManager.FEATURE_TYPE.Profile);

                new ProcessProfileSetXMLTask().Execute(this);
            }
            catch (Exception e)
            {
                statusTextView.Text = "Error setting the profile.";
                Console.WriteLine("Exception:" + e.StackTrace);
            }
        }

        #endregion

        void AddSetButtonListener()
        {
            Button btnSet = FindViewById<Button>(Resource.Id.buttonSet);

            btnSet.Click += btnSet_Click;
        }

        void btnSet_Click(object sender, EventArgs e)
        {
            // Call ModifyProfile_XMLString() to modify existing profile using XML String.
            ModifyProfile_XMLString();
        }

        private void ModifyProfile_XMLString()
        {
            statusTextView.Text = "";

            // Prepare XML to modify the existing profile
            modifyData[0] = 
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<characteristic type=\"Profile\">" +
                    "<characteristic type=\"Barcode\" version=\"0.1\">" +
                        "<characteristic type=\"Decoders\">" +
                            "<parm name=\"decoder_code128\" value=\"" + checkBoxCode128.Checked.ToString().ToLower() + "\"/>" +
                            "<parm name=\"decoder_code39\" value=\"" + checkBoxCode39.Checked.ToString().ToLower() + "\"/>" +
                            "<parm name=\"decoder_ean8\" value=\"" + checkBoxEAN8.Checked.ToString().ToLower() + "\"/>" +
                            "<parm name=\"decoder_ean13\" value=\"" + checkBoxEAN13.Checked.ToString().ToLower() + "\"/>" +
                            "<parm name=\"decoder_upca\" value=\"" + checkBoxUPCA.Checked.ToString().ToLower() + "\"/>" +
                            "<parm name=\"decoder_upce0\" value=\"" + checkBoxUPCE0.Checked.ToString().ToLower() + "\"/>" +
                        "</characteristic>" +
                    "</characteristic>" +
                "</characteristic>";

            new ProcessProfileSetXMLTask().Execute(this);
        }

    }
}

