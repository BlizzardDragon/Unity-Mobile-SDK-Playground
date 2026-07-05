using UnityEngine;

namespace _project.Scripts.Core.SDK.Firebase
{
    public class FirebaseService : MonoBehaviour
    {
        public FirebaseAnalyticsService Analytics { get; }
        public FirebaseCrashlyticsService Crashlytics { get; }
        public FirebaseRemoteConfigService RemoteConfig { get; }

        public FirebaseService()
        {
            Analytics = new FirebaseAnalyticsService();
            Crashlytics = new FirebaseCrashlyticsService();
            RemoteConfig = new FirebaseRemoteConfigService();
        }
    }
}