using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace lab1_client
{
    class Program
    {
        private const int listenPort = 11000;

        public static void StartListen()
        {
            bool done = false;
            Socket listner = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11000);
            listner.Bind(groupEP);
            var EP = groupEP as EndPoint;
            try
            {
                while (!done)
                {
                    Console.WriteLine("I'm client.");
                    byte[] bytes = new byte[1024];
                    listner.ReceiveFrom(bytes, ref EP);
                    Console.Clear();
                    Console.WriteLine("Time on server {0} ", Encoding.ASCII.GetString(bytes, 0, bytes.Length));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            finally
            {
                listner.Close();

            }
        }
        static void Main(string[] args)
        {
            StartListen();

        }
    }
}
