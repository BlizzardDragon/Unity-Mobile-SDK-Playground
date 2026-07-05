using GoogleMobileAds.Api;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public class InterstitialAdService
    {
        private InterstitialAd _interstitial;
        private readonly string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
        private bool _isAdLoaded;

        public void LoadAd()
        {
            _interstitial?.Destroy();

            var adRequest = new AdRequest();

            InterstitialAd.Load(_adUnitId, adRequest, (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    _isAdLoaded = false;
                    Debug.LogError($"Interstitial failed to load: {error}");
                    return;
                }

                _interstitial = ad;
                _isAdLoaded = true;
                Debug.Log("Interstitial loaded");

                _interstitial.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("Interstitial closed");
                    LoadAd();
                };

                _interstitial.OnAdFullScreenContentFailed += (AdError err) =>
                {
                    Debug.LogError($"Interstitial full-screen failed: {err}");
                    _isAdLoaded = false;
                };

                _interstitial.OnAdImpressionRecorded += () =>
                {
                    Debug.Log("Interstitial impression recorded");
                };
            });
        }

        public void Show()
        {
            if (_isAdLoaded && _interstitial != null)
            {
                _interstitial.Show();
                _isAdLoaded = false;
            }
            else
            {
                Debug.LogWarning("Interstitial not ready, loading...");
                LoadAd();
            }
        }
    }
}