using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RoboBeast.WP8.Resources;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.ServiceModel;
using System.Threading.Tasks;
using System.IO;
using RoboBeast.WP8.RoboServiceClient;

namespace RoboBeast.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        Accelerometer accelerometer;
        static RoboServiceClient.RoboInterfaceClient client;

        static MainPage()
        {
            client = new RoboServiceClient.RoboInterfaceClient();
            client.RegisterAsync("WP8");
        }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (!Accelerometer.IsSupported)
            {
                this.HeaderText.Text += " -- Accelerometer is not supported!"; 
            }

            Loaded += MainPage_Loaded;
        }
        
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Dispatcher.BeginInvoke(() => UpdateUI(e.SensorReading));
        }

        private void UpdateUI(AccelerometerReading accelerometerReading)
        {
            if (accelerometer == null) return;
            var acceleration = accelerometerReading.Acceleration;

            AccelerometerValue.Text = acceleration.ToString();

            xLine.X2 = xLine.X1 + acceleration.X * 200;
            yLine.Y2 = yLine.Y1 - acceleration.Y * 200;

            zLine.X2 = zLine.X1 - acceleration.Z * 100;
            zLine.Y2 = zLine.Y1 + acceleration.Z * 100;

            float motorLF=0, motorLB=0, motorRF=0, motorRB=0;
            int ct=75;// viteza motoare
            int er = 25;//cu cat scade pentru a vira

            if ((acceleration.Z < 0) && (acceleration.Y > 0))
            {
                motorLF = ct-er;
                motorRF = ct;
                motorLB = 0;
                motorRB = 0;
            }
            else if ((acceleration.Z < 0) && (acceleration.Y < 0))
            {
                motorLF = ct;
                motorRF = ct-er;
                motorLB = 0;
                motorRB = 0;
            }

            else if ((acceleration.Z > 0) && (acceleration.Y > 0))
            {
                motorLF = 0;
                motorRF = 0;
                motorLB = ct-er;
                motorRB = ct;
            }
            else if ((acceleration.Z > 0) && (acceleration.Y < 0))
            {
                motorLF = 0;
                motorRF = 0;
                motorLB = ct;
                motorRB = ct - er;
            }
            else
            {
                motorLF = 0;
                motorRF = 0;
                motorLB = 0;
                motorRB = 0;
            }





            if (client != null)
            {
                try
                {
                    client.SendDataAsync("WP8", new Data
                    {
                        Led = false,
                        LeftMotor = new Motor { Forward = (int)(motorLF), Backward = (int)(motorLB) },
                        RightMotor = new Motor { Forward = (int)(motorRF), Backward = (int)(motorRB) }
                    });
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private void stopbtn_Click_1(object sender, RoutedEventArgs e)
        {
            client.SendDataAsync("WP8", new Data
            {
                Led = false,
                LeftMotor = new Motor { Forward = 0, Backward = 0 },
                RightMotor = new Motor { Forward = 0, Backward = 0 }
            });
            accelerometer = null;
        }


        private void startbtn_Click_1(object sender, RoutedEventArgs e)
        {

            if (accelerometer == null)
            {
                accelerometer = new Accelerometer();
                accelerometer.TimeBetweenUpdates = TimeSpan.FromSeconds(0.5);
                accelerometer.CurrentValueChanged += accelerometer_CurrentValueChanged;

                try
                {
                    accelerometer.Start();
                }
                catch
                {
                    throw;
                }
            }

        }
    }
}