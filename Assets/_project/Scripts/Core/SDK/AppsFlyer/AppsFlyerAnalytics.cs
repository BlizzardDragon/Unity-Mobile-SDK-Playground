using System.Collections.Generic;

namespace _project.Scripts.Core.SDK.AppsFlyer
{
    public class AppsFlyerAnalytics
    {
        public void LogLogin()
        {
            AppsFlyerCore.SendEvent("login", new Dictionary<string, string>
            {
                {"method", "debug"}
            });
        }

        public void LogPurchase(string item, float price, string currency = "USD")
        {
            AppsFlyerCore.SendEvent("purchase", new Dictionary<string, string>
            {
                {"item", item},
                {"price", price.ToString()},
                {"currency", currency}
            });
        }

        public void LogLevelComplete(string levelId)
        {
            AppsFlyerCore.SendEvent("level_complete", new Dictionary<string, string>
            {
                {"level", levelId}
            });
        }
    }
}