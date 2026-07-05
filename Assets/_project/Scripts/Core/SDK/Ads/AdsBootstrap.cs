using _project.Scripts.Core.SDK.Statuses;

namespace _project.Scripts.Core.SDK.Ads
{
    public class AdsBootstrap
    {
        private readonly AdsService _adsService;

        public AdsBootstrap(AdsService adsService)
        {
            _adsService = adsService;
        }

        public void Initialize()
        {
            _ = UnityMainThreadDispatcher.Instance;

            _adsService.Initialize(() =>
            {
                _adsService.LoadAllAds();
                SDKStatusCoordinator.ReportState(SDKTypes.Ads, true);
            });
        }
    }
}