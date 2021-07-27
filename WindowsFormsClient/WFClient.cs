using Messenger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class WFClient : System.Windows.Forms.Form
    {
        public WFClient()
        {
            InitializeComponent();
        }

       
        private static int MessageID = 0;
        private static MessengerClientAPI API = new MessengerClientAPI();
        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                Messenger.Message msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    MessageLB.Items.Add(msg);
                    MessageID++;
                    msg = await API.GetMessageHTTPAsync(MessageID);
                }
            });
            getMessage.Invoke();
        }

        private void SendB_Click(object sender, EventArgs e)
        {
            string Username = UsernameTB.Text;
            string Message = MessageTB.Text;
            if(Username.Length > 1 && Message.Length > 1)
            {
                Messenger.Message msg = new Messenger.Message(Username, Message, DateTime.Now);
                API.SendMessageRestSharp(msg);
            }
        }
    }
}
