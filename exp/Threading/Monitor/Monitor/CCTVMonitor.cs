using System;
using System.Threading.Tasks;
using System.Threading;

namespace Monitor
{
    class CCTVMonitor
    {

        private static readonly Object obj2Lock = new Object();

        private int iID = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iID"></param>
        public CCTVMonitor(int iID)
        {
            this.iID = iID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSleepMillis"></param>
        public void process(int iSleepMillis)
        {
            this.process(iSleepMillis, 560);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSleepMillis"></param>
        /// <param name="iMillis2WaitForTheLock"></param>
        public void process(int iSleepMillis, int iMillis2WaitForTheLock)
        {

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                bool hasLock = false;

                try
                {
                    Console.WriteLine(this.ToString() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Will try to grab the lock");

                    System.Threading.Monitor.TryEnter(obj2Lock, iMillis2WaitForTheLock, ref hasLock);

                    if(hasLock)
                    {
                        Console.WriteLine(this.ToString() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId+ " Grabbed the LOCK. Sleeping time: " + iSleepMillis );
                        Thread.Sleep(iSleepMillis);
                        Console.WriteLine(this.ToString() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Will release the LOCK");
                        System.Threading.Monitor.Exit(obj2Lock);
                        Console.WriteLine(this.ToString() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId+" Released the LOCK");
                    }
                    else 
                    {
                        Console.WriteLine(
                            this.ToString() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId+
                            " Didn't grab the LOCK. Waited for " + iMillis2WaitForTheLock + " millis");
                    }
                }
                catch(Exception exc)
                {
                    Console.WriteLine(this.ToString() +" - "+ exc.ToString());
                }
            }).Start();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return "CCTVMonitor("+this.iID+")";
        }
    }
}
