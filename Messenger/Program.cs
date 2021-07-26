using System;

namespace Messenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message();
            Console.WriteLine("Hey");
            Console.WriteLine(msg.ToString());
        }
    }
}