using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gradebook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static SolidColorBrush brush = new SolidColorBrush();

        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Element.Opacity = 0.5;
            Progress.IsActive = true;
            var statusCode = await DataManager.FetchAsync(UserBox.Text, PassBox.Password);
            Progress.IsActive = false;
            Element.Opacity = 1;
            if (statusCode == DataManager.StatusCode.SUCCESS)
            {
                this.Frame.Navigate(typeof(GradePage));
            }
            else
            {
                brush.Color = Colors.Red;
                PassBox.Password = "";
                UserBox.BorderBrush = brush;
            }
        }
    }
}
