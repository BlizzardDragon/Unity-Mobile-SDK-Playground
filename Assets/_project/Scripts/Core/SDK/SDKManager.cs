using _project.Scripts.Core.SDK.AppsFlyer;
using _project.Scripts.Core.SDK.Firebase;
using UnityEngine;

namespace _project.Scripts.Core.SDK
{
    public class SDKManager : MonoBehaviour
    {
        [SerializeField] private FirebaseService _firebaseService;
        [SerializeField] private AppsFlyerService _appsFlyerService;
        
        #region Firebase

        public void OnFirebaseLevelStart()
        {
            _firebaseService.Analytics.LogLevelStart("level_1");
        }

        public void OnFirebasePurchase()
        {
            _firebaseService.Analytics.LogPurchase("sword", 1.99f);
        }

        public void OnFirebaseCrash()
        {
            _firebaseService.Crashlytics.TestCrash();
        }

        public async void OnFetchRemoteConfig()
        {
            await _firebaseService.RemoteConfig.Fetch();
        }

        public void OnShowRemoteConfig()
        {
            var value = _firebaseService.RemoteConfig.GetString("enemy_hp", "not set");
            Debug.Log($"Enemy HP: {value}");
        }

        #endregion

        #region AppsFlyer

        public void OnAppsFlyerLogin()
        {
            _appsFlyerService.Analytics.LogLogin();
        }

        public void OnAppsFlyerPurchase()
        {
            _appsFlyerService.Analytics.LogPurchase("sword", 1.99f, "USD");
        }

        public void OnAppsFlyerLevelComplete()
        {
            _appsFlyerService.Analytics.LogLevelComplete("level_1");
        }

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