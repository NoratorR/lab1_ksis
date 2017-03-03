using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Socket socet = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socet.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
        
        IPEndPoint endP = new IPEndPoint(IPAddress.Broadcast, 11000);
        socet.Connect(endP);

        Console.WriteLine("Server Work!");
        while (true)
        {
        System.Threading.Thread.Sleep(1000);
        string curTime = DateTime.Now.ToLongTimeString();
        byte[] sendbuf = Encoding.ASCII.GetBytes(curTime);
        socet.Send(sendbuf); 
        }
    }
}