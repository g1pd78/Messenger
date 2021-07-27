using System;
using Newtonsoft.Json;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Messenger
{
    class MessengerClientAPI
    {
 
        void TestJSON()
        {
            Message msg = new Message("g1pd78", "Hey", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);

            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);
        }
        public Message GetMessage(int MessageID)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messenger/" + MessageID.ToString());
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            Stream DataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(DataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            DataStream.Close();
            response.Close();
            if((status.ToLower() == "ok") && (responseFromServer != "No"))
            {
                //Console.WriteLine(responseFromServer + "!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responseFromServer);
                return deserializedMsg;
            }
            return null;
        }


        public bool SendMessage(Message msg)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messenger/");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(msg);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return true;
        }

    }
}
