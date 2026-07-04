using Firebase.Crashlytics;

namespace _project.Scripts.Core.SDK.Firebase
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
        
        // public void TestCrash()
        // {
        //     UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.AccessViolation);
        // }
    }
}