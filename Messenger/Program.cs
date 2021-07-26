using System;
using Newtonsoft.Json;


namespace Messenger
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessengerClientAPI API = new MessengerClientAPI();

        private static void GetNewMessage()
        {
            Message msg = API.GetMessage(MessageID);
            while(msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }
        static void Main(string[] args)
        {
            //Message msg = new Message();
            //Console.WriteLine("Hey");
            //Console.WriteLine(msg.ToString());

            //Message msg = new Message("g1pd78", "Hey", DateTime.UtcNow);
            //string output = JsonConvert.SerializeObject(msg);
            //Console.WriteLine(output);

            //Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            //Console.WriteLine(deserializedMsg);

            /*
             * {"UserName":"g1pd78","MessageText":"Hey","TimeStamp":"2021-07-26T15:18:16.2503617Z"}
             *  g1pd78 <26.07.2021 15:18:16>: Hey
             */

            MessageID = 1;
            Console.WriteLine("Input your name:");
            UserName = Console.ReadLine();
            string messageText = ""; ;
            while(messageText != "Exit")
            {
                Message sendMsg = new Message(UserName, messageText, DateTime.Now);
                API.SendMessage(sendMsg);
            }
        }
    }
}