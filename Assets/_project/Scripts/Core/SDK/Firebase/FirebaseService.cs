using UnityEngine;

namespace _project.Scripts.Core.SDK.Firebase
{
    public class FirebaseService : MonoBehaviour
    {
        public FirebaseAnalyticsService Analytics { get; private set; }
        public FirebaseCrashlyticsService Crashlytics { get; private set; }
        public FirebaseRemoteConfigService RemoteConfig { get; private set; }

        private void Awake()
        {
            Analytics = new FirebaseAnalyticsService();
            Crashlytics = new FirebaseCrashlyticsService();
            RemoteConfig = new FirebaseRemoteConfigService();
        }
    }
}