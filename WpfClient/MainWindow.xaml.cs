using Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int MessageID = 0;
        private static string Username;
        private static MessengerClientAPI API = new MessengerClientAPI();
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object Sender, object e)
        {
            Message msg = API.GetMessage(MessageID);
            while(msg != null)
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
