using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Core.SDK.AppsFlyer
{
    public static class AppsFlyerCore
    {
        public static void Init(string devKey, string appId, MonoBehaviour listener)
        {
            AppsFlyerSDK.AppsFlyer.initSDK(devKey, appId, listener);
            AppsFlyerSDK.AppsFlyer.startSDK();
        }

        public static void SendEvent(string eventName, Dictionary<string, string> data)
        {
            AppsFlyerSDK.AppsFlyer.sendEvent(eventName, data);
        }
    }
}