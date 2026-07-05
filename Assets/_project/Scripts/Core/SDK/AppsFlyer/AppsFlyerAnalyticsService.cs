using System.Collections.Generic;

namespace _project.Scripts.Core.SDK.AppsFlyer
{
    public class AppsFlyerAnalyticsService
    {
        public void LogLogin()
        {
            AppsFlyerSDK.AppsFlyer.sendEvent("login", new Dictionary<string, string>
            {
                {"method", "debug"}
            });
        }

        public void LogPurchase(string item, float price, string currency = "USD")
        {
            AppsFlyerSDK.AppsFlyer.sendEvent("purchase", new Dictionary<string, string>
            {
                {"item", item},
                {"price", price.ToString()},
                {"currency", currency}
            });
        }

        public void LogLevelComplete(string level)
        {
            AppsFlyerSDK.AppsFlyer.sendEvent("level_complete", new Dictionary<string, string>
            {
                {"level", level}
            });
        }
    }
}