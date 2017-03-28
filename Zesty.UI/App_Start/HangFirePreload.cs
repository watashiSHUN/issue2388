using System;
using System.Web.Hosting;
using Hangfire;

namespace Zesty.UI
{

    //
    // See http://docs.hangfire.io/en/latest/deployment-to-production/making-aspnet-app-always-running.html
    //

    
    public class ApplicationPreload : System.Web.Hosting.IProcessHostPreloadClient
    {
        public void Preload(string[] parameters)
        {
            HangfireBootstrapper.Instance.Start();
        }
    }

    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

        private readonly object _lockObject = new object();
        private bool _started;

        private BackgroundJobServer _backgroundJobServer;

        private HangfireBootstrapper()
        {
        }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;

                HostingEnvironment.RegisterObject(this);

                GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireConnection");
                
                _backgroundJobServer = new BackgroundJobServer(
                    new BackgroundJobServerOptions {
                    SchedulePollingInterval = TimeSpan.FromMinutes(1) //Default 15 seconds
                    });
            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                _backgroundJobServer?.Dispose();
                HostingEnvironment.UnregisterObject(this);
            }
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }
    }
    
}