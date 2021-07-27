using System;
using Newtonsoft.Json;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using RestSharp;

namespace Messenger
{
    class MessengerClientAPI
    {
        private static readonly HttpClient client = new HttpClient();
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

        public async Task<Message> GetMessageHTTPAsync(int MessageId)
        {
            var responseStr = await client.GetStringAsync("http://localhost:5000/api/Messenger/" + MessageId.ToString());
            if(responseStr != null)
            {
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responseStr);
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

        public Message GetMessageRestSharp(int MessageID)
        {
            string mesURL = "http://localhost:5000/";
            var client = new RestClient(mesURL);
            var request = new RestRequest("/api/Messenger/" + MessageID, Method.GET);
            IRestResponse<Message> Response = client.Execute<Message>(request);
            string responseContent = Response.Content;
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responseContent);
            return deserializedMsg;
        }

        public bool SendMessageRestSharp(Message msg)
        {
            string mesURL = "http://localhost:5000";
            var client = new RestClient(mesURL);
            var request = new RestRequest("/api/Messenger/", Method.POST);
            /////IRestResponse<Message> response = client.Execute<Message>(request);
            string output = JsonConvert.SerializeObject(msg);
            request.AddParameter("application/json; charset=utf-8", output, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            bool exit = false;
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        exit = true;
                    }
                    else
                    {
                        exit = false;
                    }
                });
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
            return exit;
        }

    }
}
