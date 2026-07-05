using System.Collections.Generic;
using AppsFlyerSDK;
using UnityEngine;

namespace _project.Scripts.Core.SDK.AppsFlyer
{
    public class AppsFlyerService : MonoBehaviour, IAppsFlyerConversionData
    {
        [Header("Config")]
        [SerializeField] private string devKey;
        [SerializeField] private string appId;

        public AppsFlyerAnalyticsService Analytics { get; }

        public AppsFlyerService()
        {
            Analytics = new AppsFlyerAnalyticsService();
        }

        public void Initialize()
        {
            AppsFlyerSDK.AppsFlyer.initSDK(devKey, appId, this);
            AppsFlyerSDK.AppsFlyer.startSDK();

            Debug.Log("AppsFlyer initialized");
        }

        // ---------------- Callbacks ----------------

        public void onConversionDataSuccess(string conversionData)
        {
            Debug.Log(conversionData);
        }

        public void onConversionDataFail(string error)
        {
            Debug.LogError(error);
        }

        public void onAppOpenAttribution(string attributionData)
        {
            Debug.Log(attributionData);
        }

        public void onAppOpenAttributionFailure(string error)
        {
            Debug.LogError(error);
        }
    }
}