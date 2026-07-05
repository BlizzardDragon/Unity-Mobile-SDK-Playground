using System;
using GoogleMobileAds.Api;
using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public class AdsService : MonoBehaviour
    {
        [SerializeField] private List<string> _testDeviceIds;

        public BannerAdService Banner { get; }
        public InterstitialAdService Interstitial { get; }
        public RewardedAdService Rewarded { get; }

        public AdsService()
        {
            Banner = new BannerAdService();
            Interstitial = new InterstitialAdService();
            Rewarded = new RewardedAdService();
        }

        public void Initialize(Action onComplete)
        {
            var requestConfig = new RequestConfiguration
            {
                TestDeviceIds = _testDeviceIds
            };

            MobileAds.SetRequestConfiguration(requestConfig);

            MobileAds.Initialize(_ =>
            {
                UnityMainThreadDispatcher.Instance.Execute(() =>
                {
                    Debug.Log("Google Mobile Ads initialized");
                    onComplete?.Invoke();
                });
            });
        }

        public void LoadAllAds()
        {
            Banner.LoadAd();
            Interstitial.LoadAd();
            Rewarded.LoadAd();
        }
    }
}