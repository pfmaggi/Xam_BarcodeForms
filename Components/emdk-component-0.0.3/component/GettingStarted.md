
# EMDK For Xamarin - Alpha 
Welcome to the EMDK for Xamarin Alpha. This Alpha will provide you with ability to use Zebra's EMDK features within your Xamarin application. Please be sure to read the contents of this guide in it's entirety to ensure your evironment is properly setup

**Features Supported**

- Profile Manager Visual Studio (2012+) Plugin
- Symbol.XamarinEMDK APIs
	- EMDKManager, ProfileManager, VersionManager,  Barcode (See known issues below)

**Not Yet Implemented**

- Xamarin Studio Add-In
- Mac Support

**Known Issues:**

The following field and class names might change during the release. The Alpha customer might have to modify their application to get the new names.

**Field names:**

- ProfileConfig.dataCaptures
- ProfileConfig.barcodes
- ScannerConfig.readerParam

**Class names:**

- ProfileConfig.DataCapture
- ProfileConfig.Barcode
- ScannerConfig.ReaderParams

The application must use the **readerParams** instead of **readerParam** to check the parameter supported using ScannerConfig.isParamSupported.

Ex:

ScannerConfig.isParamSupported("config1.readerParams.decodeHapticFeedback")

## 1) Complete IDE Setup
Installing the Xamarin Component only enables the EMDK API library, you must complete the installation of the IDE integration. This step only needs to be performed once, however adding the EMDK For Xamarin component needs to be performed for each project you wish to include it in.

- [Read the Visual Studio Setup Guide](http://emdk.github.io/xamarin-docs/edge/#guide-vs-setup)

## 2) Try the Sample
A sample is included as part of the Xamarin Component package to help get you started. Click on the **samples** tab on the component details page to add it to your solution project.

- [Read the Using Xamarin Samples Guide](http://emdk.github.io/xamarin-docs/edge/#guide-sample-about)

## 3) Understand Profile Manager
One unique feature to EMDK for Xamarin is to control device behavior and configuration through the use of *profiles*. The EMDK Profile Manager lets you create profiles right from your IDE using a GUI interface for selecting the features and settings that your application wishes to use. Then in your application you would simply apply the profile when needed. This results in a simple approach and minimal lines of code required to accomplish tasks

- [Read the Profile Manager Overview Guide](http://emdk.github.io/xamarin-docs/edge/#guide-profiles-about)

## 4) Build a Simple Application
Now that you have your environment setup and have an overview of the EMDK for Xamarin, let's walk through and build an application from scratch.

- [Follow the Hello Xamarin tutorial](http://emdk.github.io/xamarin-docs/edge/#guide-tutorial-helloxamarin)

## 5) Check out our docs
We have a lot more resources for you to benefit from:

- API reference
- Developer Guides
- Tutorials
- Videos
- More Samples

## 6) Report Feedback/Issues
Thanks for taking the time to try out this alpha. We would love to hear your [feedback or issues](https://github.com/emdk/xamarin-docs/issues/new?title=EMDK%20For%20Xamarin) you have encountered. Note; A GitHub account is required to create issues, please log into Github before submitting an issue.


- [Check our full online docs](http://emdk.github.io/xamarin-docs/edge)

