using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Ads
{
    public static class AdsCore
    {
        public static void Initialize(Action<InitializationStatus> onComplete)
        {
            var requestConfig = new RequestConfiguration
            {
                TestDeviceIds = new List<string>
                {
                    "E459B4FF1D81AC6F930D04373E204480"
                }
            };
            MobileAds.SetRequestConfiguration(requestConfig);

            // Проверка: выводим установленный список
            Debug.Log($"Test Device IDs set: {string.Join(", ", requestConfig.TestDeviceIds)}");

            MobileAds.Initialize(status =>
            {
                UnityMainThreadDispatcher.Instance.Execute(() =>
                {
                    Debug.Log("Google Mobile Ads initialized");
                    onComplete?.Invoke(status);
                });
            });
        }    }
}