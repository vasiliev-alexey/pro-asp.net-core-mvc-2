namespace ConfiguringApps.Infrastructure
{
    using System.Diagnostics;
    using System.Threading;

    public class UptimeService
    {
        private Stopwatch timer
            
            ;

        public UptimeService()
        {
             timer = Stopwatch.StartNew();
        }

        /// <summary>
        /// The uptime.
        /// </summary>
        public long Uptime => timer.ElapsedMilliseconds;

    }
}