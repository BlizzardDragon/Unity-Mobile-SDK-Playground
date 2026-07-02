using Firebase.Crashlytics;

namespace _project.Scripts.Services.Firebase
{
    public class FirebaseCrashlyticsService
    {
        public void LogMessage(string message)
        {
            Crashlytics.Log(message);
        }

        public void TestCrash()
        {
            throw new System.Exception("Test Crash from SDK Playground");
        }
    }
}