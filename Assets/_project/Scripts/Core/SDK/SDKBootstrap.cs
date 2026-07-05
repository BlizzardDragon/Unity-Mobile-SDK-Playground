using _project.Scripts.Core.SDK.Ads;
using _project.Scripts.Core.SDK.AppsFlyer;
using _project.Scripts.Core.SDK.Firebase;
using _project.Scripts.Core.SDK.Statuses;
using _project.Scripts.UI.SDK;
using UnityEngine;

namespace _project.Scripts.Core.SDK
{
    public class SDKBootstrap : MonoBehaviour
    {
        [SerializeField] private AppsFlyerService _appsFlyerService;
        [SerializeField] private AdsService _adsService;
        [SerializeField] private SDKStatusView _sdkStatusView;

        private SDKStatusService _sdkStatusService;
        private SDKStatusViewPresenter _sdkStatusViewPresenter;

        private void Awake()
        {
            _sdkStatusService = new SDKStatusService();
            _sdkStatusViewPresenter = new SDKStatusViewPresenter(_sdkStatusService, _sdkStatusView);

            var firebaseBootstrap = new FirebaseBootstrap();
            var appsFlyerBootstrap = new AppsFlyerBootstrap(_appsFlyerService);
            var adsBootstrap = new AdsBootstrap(_adsService);

            _sdkStatusViewPresenter.OnEnable();
            _sdkStatusService.Initialize();

            firebaseBootstrap.Initialize();
            appsFlyerBootstrap.Initialize();
            adsBootstrap.Initialize();
        }

        private void OnDestroy()
        {
            _sdkStatusViewPresenter.OnDisable();
            _sdkStatusService.Dispose();
        }
    }
}