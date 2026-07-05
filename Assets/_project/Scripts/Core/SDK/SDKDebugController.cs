using _project.Scripts.Core.SDK.Ads;
using _project.Scripts.Core.SDK.AppsFlyer;
using _project.Scripts.Core.SDK.Firebase;
using UnityEngine;

namespace _project.Scripts.Core.SDK
{
    public class SDKDebugController : MonoBehaviour
    {
        [SerializeField] private FirebaseService _firebaseService;
        [SerializeField] private AppsFlyerService _appsFlyerService;
        [SerializeField] private AdsService _adsService;
        
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

        public void OnShowBanner()
        {
            _adsService.Banner.Show();
        }

        public void OnHideBanner()
        {
            _adsService.Banner.Hide();
        }

        public void OnShowInterstitial()
        {
            _adsService.Interstitial.Show();
        }

        public void OnShowRewarded()
        {
            _adsService.Rewarded.Show((success) =>
            {
                if (success)
                    Debug.Log("Player earned reward!");
                else
                    Debug.Log("Reward not earned");
            });
        }

        #endregion
    }
}