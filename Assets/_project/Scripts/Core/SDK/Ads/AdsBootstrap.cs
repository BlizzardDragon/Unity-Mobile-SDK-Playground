using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public class AdsBootstrap : MonoBehaviour
    {
        [SerializeField] private AdsService _adsService;

        private void Awake()
        {
            var dispatcher = UnityMainThreadDispatcher.Instance;

            AdsCore.Initialize(_ =>
            {
                SDKStatusCoordinator.ReportState(SDKTypes.Ads, true);
                _adsService.LoadAllAds();
            });
        }
    }
}