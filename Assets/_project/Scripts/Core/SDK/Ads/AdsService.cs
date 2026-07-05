using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public class AdsService : MonoBehaviour
    {
        public BannerAdService Banner { get; private set; }
        public InterstitialAdService Interstitial { get; private set; }
        public RewardedAdService Rewarded { get; private set; }

        private void Awake()
        {
            Banner = new BannerAdService();
            Interstitial = new InterstitialAdService();
            Rewarded = new RewardedAdService();
        }

        public void LoadAllAds()
        {
            Banner.LoadAd();
            Interstitial.LoadAd();
            Rewarded.LoadAd();
        }
    }
}