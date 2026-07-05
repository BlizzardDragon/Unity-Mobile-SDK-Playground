using _project.Scripts.Core.SDK.Statuses;

namespace _project.Scripts.Core.SDK.AppsFlyer
{
    public class AppsFlyerBootstrap
    {
        private readonly AppsFlyerService _service;

        public AppsFlyerBootstrap(AppsFlyerService service)
        {
            _service = service;
        }

        public void Initialize()
        {
            _service.Initialize();

            SDKStatusCoordinator.ReportState(SDKTypes.AppsFlyer, true);
        }
    }
}