namespace _project.Scripts.Core.SDK.Statuses
{
    public struct SDKStatus
    {
        public bool Firebase;
        public bool AppsFlyer;
        public bool Ads;

        public bool AllReady => Firebase && AppsFlyer && Ads;
    }
}