﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }
 
 
            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                
                // get url 
                Console.WriteLine($"Received request for {request.Url}");

                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);

                // parse path in url
                string seg = "";
                foreach (string str in request.Url.Segments)
                {
                    Console.WriteLine("segment: "+ str);
                    seg = str;
                }

                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);

                string param1 = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                string param2 = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");
                //parse params in url
                Console.WriteLine("param1 = " + param1);
                Console.WriteLine("param2 = " + param2);
                Console.WriteLine("param3 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param3"));
                Console.WriteLine("param4 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param4"));

                //
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                Type type = typeof(MyReflectionClass);
                MethodInfo method = type.GetMethod(seg);
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                if (method != null)
                {
                    MyReflectionClass c = new MyReflectionClass();
                    responseString = (string)method.Invoke(c, new object[] { param1, param2 });
                }

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }

    public class MyReflectionClass
    {
        public string MyMethod(string param1, string param2)
        {
            Console.WriteLine("Call MyMethod 1");
            return "<html><body>Hello " + param1 + " et " + param2 + "</body></html>";
        }

        public string incr(string param1, string param2)
        {
            string r = "";
            try
            {
                r = "" + (Int32.Parse(param1) + 1);
            }
            catch (Exception)
            {
                r = "0";
            }

            return r;
        }

        public string ping(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\windows\system32\ping.exe"; // Specify exe name.
            start.Arguments = "-n 1 " + param1; // Specify arguments.
            start.UseShellExecute = false; 
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            string r = "";
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                
                using (StreamReader reader = process.StandardOutput)
                {
                    r += reader.ReadToEnd();
                }
            }

            return r;
        }
    }
}