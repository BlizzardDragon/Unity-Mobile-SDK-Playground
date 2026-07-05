using GoogleMobileAds.Api;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public class BannerAdService
    {
        private BannerView _bannerView;
        private readonly string _adUnitId = "ca-app-pub-3940256099942544/6300978111";

        public void LoadAd()
        {
            _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);

            _bannerView.OnBannerAdLoaded += () =>
            {
                Debug.Log("Banner loaded");
                _bannerView.Hide();
            };
            _bannerView.OnBannerAdLoadFailed += (error) => Debug.LogError($"Banner failed: {error}");

            _bannerView.LoadAd(new AdRequest());
        }

        public void Show()
        {
            _bannerView?.Show();
        }

        public void Hide()
        {
            _bannerView?.Hide();
        }

        public void Destroy()
        {
            _bannerView?.Destroy();
            _bannerView = null;
        }
    }
}