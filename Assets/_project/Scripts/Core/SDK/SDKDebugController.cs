using _project.Scripts.Core.SDK.Ads;
using _project.Scripts.Core.SDK.AppsFlyer;
using _project.Scripts.Core.SDK.Firebase;
using TMPro;
using UnityEngine;

namespace _project.Scripts.Core.SDK
{
    public class SDKDebugController : MonoBehaviour
    {
        private const string LevelId = "level_1";
        private const string ItemId = "sword";
        private const string ConfigId = "enemy_hp";

        [Header("Services")]
        [SerializeField] private FirebaseService _firebaseService;
        [SerializeField] private AppsFlyerService _appsFlyerService;
        [SerializeField] private AdsService _adsService;
        
        [Header("UIText")]
        [SerializeField] TMP_Text _enemyHPText;
        [SerializeField] TMP_Text _configDownloadedText;
        
        #region Firebase

        public void OnFirebaseLevelStart()
        {
            _firebaseService.Analytics.LogLevelStart(LevelId);
        }

        public void OnFirebasePurchase()
        {
            _firebaseService.Analytics.LogPurchase(ItemId, 1.99f);
        }

        public void OnFirebaseCrash()
        {
            _firebaseService.Crashlytics.TestCrash();
        }

        public async void OnFetchRemoteConfig()
        {
            await _firebaseService.RemoteConfig.Fetch();
            _configDownloadedText.enabled = true;
        }

        public void OnShowRemoteConfig()
        {
            var value = _firebaseService.RemoteConfig.GetString(ConfigId, "not set");
            var enemyHP = $"Enemy HP: {value}";
            
            _enemyHPText.text = enemyHP;
            _enemyHPText.enabled = true;
        }

        #endregion

        #region AppsFlyer

        public void OnAppsFlyerLogin()
        {
            _appsFlyerService.Analytics.LogLogin();
        }

        public void OnAppsFlyerPurchase()
        {
            _appsFlyerService.Analytics.LogPurchase(ItemId, 1.99f, "USD");
        }

        public void OnAppsFlyerLevelComplete()
        {
            _appsFlyerService.Analytics.LogLevelComplete(LevelId);
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
            _adsService.Rewarded.Show(success =>
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