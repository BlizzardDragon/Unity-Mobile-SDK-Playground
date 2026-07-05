using System;

namespace _project.Scripts.Core.SDK.Statuses
{
    public static class SDKStatusCoordinator
    {
        public static event Action<SDKTypes, bool> OnSDKStateChanged;

        public static void ReportState(SDKTypes sdkName, bool isReady)
        {
            OnSDKStateChanged?.Invoke(sdkName, isReady);
        }
    }
}