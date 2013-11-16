using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RoboBeast.Win8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tileXmlString =
                "<tile>"
                + "<visual version='2'>"
                  + "<binding template='TileWide310x150PeekImageCollection05' fallback='TileWidePeekImageCollection05'>"
                    + "<image id='1' src='Assets/mic.jpg' alt='larger image'/>"
                    + "<image id='2' src='Assets/mic.jpg' alt='small image, row 1, column 1'/>"
                    + "<image id='3' src='Assets/mic.jpg' alt='small image, row 1, column 2'/>"
                    + "<image id='4' src='Assets/mic.jpg' alt='small image, row 2, column 1'/>"
                    + "<image id='5' src='Assets/mic.jpg' alt='small image, row 2, column 2'/>"
                    + "<image id='6' src='Assets/mic.jpg' alt='image next to text'/>"
                    + "<text id='1'>Arduino is ON</text>"
                    + "<text id='2'>Kinect is ON\nEnter to PLAY now</text>"
                  + "</binding>"
                + "</visual>"
                + "</tile>";

            // Create a DOM.
            Windows.Data.Xml.Dom.XmlDocument tileDOM = new Windows.Data.Xml.Dom.XmlDocument();

            // Load the xml string into the DOM.
            tileDOM.LoadXml(tileXmlString);
            var notification = new Windows.UI.Notifications.TileNotification(tileDOM);
            var upd = Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication();
            upd.Update(notification);
        }

        
    }
}
