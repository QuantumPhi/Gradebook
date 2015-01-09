using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Gradebook.Resources;
using System.Windows.Media;

namespace Gradebook
{
    public partial class MainPage : PhoneApplicationPage
    {
        private static readonly SolidColorBrush brush = new SolidColorBrush();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void UserBox_GotFocus(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text == "Username")
            {
                textbox.Text = "";
            }
            brush.Color = Colors.Black;
            textbox.Foreground = brush;
        }

        private void UserBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text == String.Empty)
            {
                textbox.Text = "Username";
                brush.Color = Colors.Gray;
                textbox.Foreground = brush;
            }
        }

        private void PassBox_GotFocus(object sender, EventArgs e)
        {
            var textbox = sender as PasswordBox;
            var watermark = PassBox_Watermark;
            if(textbox.Opacity == 0)
            {
                textbox.Opacity = 100;
                watermark.Opacity = 0;
            }
        }

        private void PassBox_LostFocus(object sender, EventArgs e)
        {
            var textbox = sender as PasswordBox;
            var watermark = PassBox_Watermark;
            if(textbox.Password == String.Empty)
            {
                textbox.Opacity = 0;
                watermark.Opacity = 100;
            }
        }

        private void PassBox_Watermark_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}