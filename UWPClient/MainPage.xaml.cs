using System;
using Messenger;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWPClient
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string Username;
        private static int MessageID = 0;
        private static MessengerClientAPI API = new MessengerClientAPI();
        DispatcherTimer timer;
        public MainPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Message msg = API.GetMessage(MessageID);
            while (msg != null)
            {
                MessageLB.Items.Add(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }
        private void SendB_Click(object sender, RoutedEventArgs e)
        {
            string Username = UsernameTB.Text;
            string Message = MessageTB.Text;
            if(Username.Length > 1 && Message.Length > 1)
            {
                Message msg = new Message(Username, Message, DateTime.Now);
                API.SendMessage(msg);
            }
        }
    }
}
