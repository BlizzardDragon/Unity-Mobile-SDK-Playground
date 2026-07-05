using GoogleMobileAds.Api;
using System;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public static class AdsCore
    {
        public static void Initialize(Action<InitializationStatus> onComplete)
        {
            MobileAds.Initialize(status =>
            {
                // Переключаемся в главный поток
                UnityMainThreadDispatcher.Instance.Execute(() =>
                {
                    Debug.Log("Google Mobile Ads initialized");
                    onComplete?.Invoke(status);
                });
            });
        }
    }
}