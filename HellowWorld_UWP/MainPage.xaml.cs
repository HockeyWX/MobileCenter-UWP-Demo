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
using Windows.Networking.PushNotifications;
using System.Diagnostics;
using Microsoft.Azure.Mobile.Utils;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HellowWorld_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            SetupSelfNotification();

            GetApplicationState();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void SetupSelfNotification()
        {
            PushNotificationChannel channel1 = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            this.URITextBlock.Text = channel1.Uri;
            Debug.WriteLine("channelURI" + channel1.Uri);

            PushNotificationChannel channel2 = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            bool ChannelIsEqual = channel1 == channel2;

            channel1.PushNotificationReceived += OnPushNotificationReceivedHandler1;
            channel2.PushNotificationReceived += OnPushNotificationReceivedHandler2;
        }

        int i = 0;
        private void OnPushNotificationReceivedHandler1(PushNotificationChannel sender, PushNotificationReceivedEventArgs e)
        {
            i++;
            Debug.WriteLine("InvokeHandlerCount_Handler1 : " + i);
        }

        int j = 0;
        private void OnPushNotificationReceivedHandler2(PushNotificationChannel sender, PushNotificationReceivedEventArgs e)
        {
            j++;
            Debug.WriteLine("InvokeHandlerCount_Hanlder2 : " + j);
        }

        private void GetApplicationState()
        {
            bool isSuspended = ApplicationLifecycleHelper.Instance.IsSuspended;
            this.ApplicationStateTB.Text = isSuspended.ToString();

        }


    }
}
