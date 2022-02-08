using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Echo
{
    class EchoServer
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(5000);
            ServerSocket.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine(Environment.GetEnvironmentVariable("HTTP_ROOT"));
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                handleClient client = new handleClient();
                client.startClient(clientSocket);
            }


        }
    }

    public class handleClient
    {
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }

        static Encoding enc = Encoding.UTF8;

        private void Echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            MemoryStream memoryStream = new MemoryStream();
            byte[] data = new byte[1000];
            int size;
            do
            {
                size = stream.Read(data, 0, data.Length);
                if (size == 0)
                {
                    Console.WriteLine("client disconnected...");
                    return;
                }
                memoryStream.Write(data, 0, size);
            } while (stream.DataAvailable);
            string request = enc.GetString(memoryStream.ToArray());
            using var reader = new StringReader(request);
            string first = reader.ReadLine();
            string path = first.Substring(4, first.Length - 13);
            string fullPath = Environment.GetEnvironmentVariable("HTTP_ROOT") + "\\" + path;
            if(!File.Exists(fullPath))
            {
                stream.Close();
                return;
            }
            string fileContent = File.ReadAllText(fullPath);
            System.Net.HttpRequestHeader
            string httpHeader = "HTTP / 1.1 200 OK\nContent - Length: " + fileContent.Length + "\nContent - Type: text / html\nConnection: Close\n\n" + fileContent;
            stream.Write(enc.GetBytes(httpHeader));
            stream.Close();
            Console.WriteLine(request);
        }



    }

}