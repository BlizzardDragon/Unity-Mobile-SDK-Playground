using _project.Scripts.Core;
using _project.Scripts.Core.SDK;
using _project.Scripts.Core.SDK.Firebase;
using TMPro;
using UnityEngine;

namespace _project.Scripts.UI
{
    public class SDKDebugPanel : MonoBehaviour
    {
        [Header("Status")]
        [SerializeField] private TMP_Text _firebaseStatus;
        [SerializeField] private TMP_Text _appsFlyerStatus;
        [SerializeField] private TMP_Text _adsStatus;
        [SerializeField] private TMP_Text _globalStatus;

        private void OnEnable()
        {
            SDKManager.OnStatusChanged += Refresh;
        }

        private void OnDisable()
        {
            SDKManager.OnStatusChanged -= Refresh;
        }

        private void Refresh(SDKStatus status)
        {
            _firebaseStatus.text = status.Firebase ? "Firebase: READY" : "Firebase: OFF";
            _appsFlyerStatus.text = status.AppsFlyer ? "AppsFlyer: READY" : "AppsFlyer: OFF";
            _adsStatus.text = status.Ads ? "Ads: READY" : "Ads: OFF";

            _globalStatus.text = status.AllReady ? "ALL SYSTEMS READY" : "INITIALIZING...";
        }
        
        #region Firebase

        public void OnFirebaseLevelStart()
        {
            FirebaseManager.Firebase.Analytics.LogLevelStart("level_1");
        }

        public void OnFirebasePurchase()
        {
            FirebaseManager.Firebase.Analytics.LogPurchase("sword", 1.99f);
        }

        public void OnFirebaseCrash()
        {
            FirebaseManager.Firebase.Crashlytics.TestCrash();
        }

        public async void OnFetchRemoteConfig()
        {
            await FirebaseManager.Firebase.RemoteConfig.Fetch();
        }

        public void OnShowRemoteConfig()
        {
            var value = FirebaseManager.Firebase.RemoteConfig.GetString("enemy_hp", "not set");
            Debug.Log($"Enemy HP: {value}");
        }

        #endregion

        #region AppsFlyer

        // Раскомментировать после подключения AppsFlyer.

        /*
        public void OnAppsFlyerLogin()
        {
            AppsFlyerManager.AppsFlyer.Analytics.LogLogin();
        }

        public void OnAppsFlyerPurchase()
        {
            AppsFlyerManager.AppsFlyer.Analytics.LogPurchase("sword", 1.99f, "USD");
        }

        public void OnAppsFlyerLevelComplete()
        {
            AppsFlyerManager.AppsFlyer.Analytics.LogLevelComplete("level_1");
        }
        */

        #endregion

        #region Google Mobile Ads

        // Раскомментировать после подключения Google Mobile Ads.

        /*
        public void OnShowBanner()
        {
            AdsManager.Ads.ShowBanner();
        }

        public void OnHideBanner()
        {
            AdsManager.Ads.HideBanner();
        }

        public void OnShowInterstitial()
        {
            AdsManager.Ads.ShowInterstitial();
        }

        public void OnShowRewarded()
        {
            AdsManager.Ads.ShowRewarded();
        }
        */

        #endregion
    }
}