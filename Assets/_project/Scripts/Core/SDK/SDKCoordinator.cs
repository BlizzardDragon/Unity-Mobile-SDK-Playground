using System;

namespace _project.Scripts.Core.SDK
{
    public static class SDKCoordinator
    {
        public static event Action<string, bool> OnSDKStateChanged;

        public static void ReportState(string sdkName, bool isReady)
        {
            OnSDKStateChanged?.Invoke(sdkName, isReady);
        }
    }
}