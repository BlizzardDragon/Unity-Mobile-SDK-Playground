using _project.Scripts.Core;
using UnityEngine;

namespace _project.Scripts.UI
{
    public class FirebaseDebugPanel : MonoBehaviour
    {
        public void OnLevelStart()
        {
            FirebaseManager.Firebase.Analytics.LogLevelStart("level_1");
        }

        public void OnPurchase()
        {
            FirebaseManager.Firebase.Analytics.LogPurchase("sword", 1.99f);
        }

        public void OnCrash()
        {
            FirebaseManager.Firebase.Crashlytics.TestCrash();
        }

        public async void OnFetchRemoteConfig()
        {
            await FirebaseManager.Firebase.RemoteConfig.Fetch();
        }

        public void OnShowConfig()
        {
            var value = FirebaseManager.Firebase.RemoteConfig.GetString("enemy_hp", "not set");
            Debug.Log($"Enemy HP: {value}");
        }
    }
}