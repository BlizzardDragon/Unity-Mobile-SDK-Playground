using GoogleMobileAds.Api;
using System;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public class RewardedAdService
    {
        private RewardedAd _rewardedAd;
        private readonly string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
        private bool _isAdLoaded;
        private Action<bool> _onRewardCallback;

        public void LoadAd()
        {
            _rewardedAd?.Destroy();

            var adRequest = new AdRequest();

            RewardedAd.Load(_adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    _isAdLoaded = false;
                    Debug.LogError($"Rewarded failed to load: {error}");
                    return;
                }

                _rewardedAd = ad;
                _isAdLoaded = true;
                Debug.Log("Rewarded loaded");

                _rewardedAd.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("Rewarded closed");
                    
                    if (_onRewardCallback != null)
                    {
                        _onRewardCallback(false);
                        _onRewardCallback = null;
                    }
                    LoadAd();
                };

                _rewardedAd.OnAdFullScreenContentFailed += (AdError err) =>
                {
                    Debug.LogError($"Rewarded full-screen failed: {err}");
                    _isAdLoaded = false;
                    _onRewardCallback?.Invoke(false);
                    _onRewardCallback = null;
                };

                _rewardedAd.OnAdImpressionRecorded += () =>
                {
                    Debug.Log("Rewarded impression recorded");
                };

                _rewardedAd.OnAdPaid += (AdValue adValue) =>
                {
                    Debug.Log($"Rewarded ad paid: {adValue.Value}");
                };
            });
        }

        public void Show(Action<bool> onReward = null)
        {
            _onRewardCallback = onReward;

            if (_isAdLoaded && _rewardedAd != null)
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    Debug.Log($"Reward earned: {reward.Amount} {reward.Type}");
                    _onRewardCallback?.Invoke(true);
                    _onRewardCallback = null;
                });
                _isAdLoaded = false;
            }
            else
            {
                Debug.LogWarning("Rewarded not ready, loading...");
                LoadAd();
                _onRewardCallback?.Invoke(false);
                _onRewardCallback = null;
            }
        }
    }
}