using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace BarcodeForms
{
    public class MainPage : ContentPage
    {
        Entry txtBarcode;
        Button btnScan;

        public MainPage()
        {
            this.Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
            };

            panel.Children.Add(new Label
            {
                Text = "Enter a Phoneword:",
            });

            panel.Children.Add(txtBarcode = new Entry
            {
                Text = "",
            });

            panel.Children.Add(btnScan = new Button
            {
                Text = "Scan"
            });

            btnScan.Clicked += OnScan;

            this.Content = panel;
        }

        void OnScan(object sender, System.EventArgs e)
        {
            var scanner = DependencyService.Get<IScanner>();
            if (scanner != null)
            {
                scanner.Scan();
            }
        }
    }
}
