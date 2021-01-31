using System;
using System.Text;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Windows;
using AdminPanel.Content.Views.Components.Meters;

namespace AdminPanel.Data.Server.Performance.Tools
{
    class Process
    {

        public static string IPServerAPI = "149.28.37.80";

        public static void GetPing(object args)
        {
            object[] obj = (object[])args;
            string ip = (string)obj.GetValue(0);
            CircularProgressbar bar = (CircularProgressbar)obj.GetValue(1);
            PerformanceTracker tracker = (PerformanceTracker)obj.GetValue(2);

            while (true)
            {
                Ping ping = new Ping();
                PingOptions options = new PingOptions
                {
                    DontFragment = true
                };

                string data = "aaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                PingReply reply = null;

                try
                {
                    reply = ping.Send(ip, 120, buffer, options);
                    if (reply.Status == IPStatus.Success)
                        bar.Dispatcher.Invoke(
                            new PerformanceTracker.UpdatePingCallback(tracker.UpdatePing),
                            unchecked((int)reply.RoundtripTime)
                        );
                    Thread.Sleep(1000);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    Thread.CurrentThread.Abort();
                }
            }
        }

    }
}
