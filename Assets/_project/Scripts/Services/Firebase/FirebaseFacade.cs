namespace _project.Scripts.Services.Firebase
{
    public class FirebaseFacade
    {
        public FirebaseAnalyticsService Analytics { get; private set; }
        public FirebaseCrashlyticsService Crashlytics { get; private set; }
        public FirebaseRemoteConfigService RemoteConfig { get; private set; }

        public FirebaseFacade()
        {
            Analytics = new FirebaseAnalyticsService();
            Crashlytics = new FirebaseCrashlyticsService();
            RemoteConfig = new FirebaseRemoteConfigService();
        }
    }
}