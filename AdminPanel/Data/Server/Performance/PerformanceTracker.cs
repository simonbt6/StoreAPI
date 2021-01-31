using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AdminPanel.Data.Server.Performance.Tools;
using System.Windows.Controls;
using System.Windows;
using AdminPanel.Content.Views.Components.Meters;

namespace AdminPanel.Data.Server.Performance
{
    public class PerformanceTracker
    {
        private CircularProgressbar bar;
        private Thread pingThread;

        public delegate void  UpdatePingCallback(int ping);

        public PerformanceTracker()
        {
            
        }

        public void UpdatePing(int ping)
        {
            bar.Value = ping;
        }

        // Ping thread process.

        // List of all threads running.
        private List<Thread> runningThreads = new List<Thread>();

        /**
         * <summary>Start ping thread if not alive.</summary>
         **/
        public void StartPing(CircularProgressbar bar)
        {
            this.bar = bar;
            if (pingThread == null)
            {
                pingThread = new Thread(new ParameterizedThreadStart(Process.GetPing));
                pingThread.Start(new object[]{
                    Process.IPServerAPI,
                    bar,
                    this
                });
                runningThreads.Add(pingThread);
                
            }
        }

        /**
         * <summary>Abort ping thread if alive.</summary>
         **/
        public void StopPing()
        {
            if (pingThread.IsAlive)
            {
                pingThread.Abort();
                runningThreads.Remove(pingThread);
            }
        }

        public Thread PingThread()
        {
            return pingThread;
        }

        /**
         * <summary>Aborts all running threads.</summary>
         * 
         **/
        public void StopAll()
        {
            foreach(Thread thread in runningThreads.ToArray())
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                    runningThreads.Remove(thread);
                }
            }
        }
    }
}
