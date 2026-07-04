using Firebase.Analytics;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Firebase
{
    public class FirebaseAnalyticsService
    {
        public void LogLevelStart(string levelName)
        {
            FirebaseAnalytics.LogEvent("level_start", "level_name", levelName);
            Debug.Log($"Analytics: level_start {levelName}");
        }

        public void LogPurchase(string itemId, float price)
        {
            FirebaseAnalytics.LogEvent(
                "purchase",
                new Parameter("item_id", itemId),
                new Parameter("price", price)
            );

            Debug.Log($"Analytics: purchase {itemId} {price}");
        }

        public void LogCustom(string eventName)
        {
            FirebaseAnalytics.LogEvent(eventName);
        }
    }
}