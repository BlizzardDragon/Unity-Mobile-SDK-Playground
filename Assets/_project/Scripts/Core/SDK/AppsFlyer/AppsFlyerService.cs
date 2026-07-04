using System;
using AppsFlyerSDK;
using UnityEngine;

namespace _project.Scripts.Core.SDK.AppsFlyer
{
    public class AppsFlyerService : MonoBehaviour, IAppsFlyerConversionData
    {
        [Header("Config")]
        [SerializeField] private string devKey = "DEV_KEY";
        [SerializeField] private string appId = "APP_ID";

        public AppsFlyerAnalytics Analytics { get; private set; }

        private bool _isInitialized;

        private void Start()
        {
            Analytics = new AppsFlyerAnalytics();
            Init();
        }

        private void Init()
        {
            AppsFlyerCore.Init(devKey, appId, this);

            _isInitialized = true;

            Debug.Log("AppsFlyer initialized");

            SDKStatusCoordinator.ReportState(SDKTypes.AppsFlyer, true);
        }

        // -------- CALLBACKS --------

        public void onConversionDataSuccess(string conversionData)
        {
            Debug.Log("AppsFlyer conversion data received: " + conversionData);
        }

        public void onConversionDataFail(string error)
        {
            Debug.LogError($"AppsFlyer conversion failed: {error}");
        }

        public void onAppOpenAttribution(string attributionData)
        {
            Debug.Log("App open attribution: " + attributionData);
        }

        public void onAppOpenAttributionFailure(string error)
        {
            Debug.LogError($"App open attribution failed: {error}");
        }
    }
}