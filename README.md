# Xam_BarcodeIntent
EMDK for Xamarin, Xamarin.Forms Sample with Profile Manager API and Broadcast Intents

## Intro
I'm not a C# developer, at least not mainly, and I've so my code is probably not idiomatic. If you have suggestion on how to improve this sample, fill free to open an issue or send a pull request.

## Description
The application implement a simple Xamarin.Forms app with a button and an Entry.
Pressing the Scan button, the barcode is activated and when you read a CODE128 or an EAN13, the data is displayed in the Entry.

## How is done
The Activity of the Android project use the Profile API to configure DataWedge to read EAN13 and CODE128 barcodes and to send the data with a Broadcast intent. This configuration is assigned to the activity itself (com.pietromaggi.sample,barcodeForms.MainActivity).

The Form uses a DependencyService to send a DataWedge intent (the interface is in the Portable library, I've implemented only the Android side).

A broadcast receiver is implemented to handle the Intent coming from DataWedge, this receiver is registered in the MainActivity and an event handler is registered there to handle the received data,

The event handler uses the MessagingCenter to send the data to the Form so that it can display the data.

~Pietro
@pfmaggi