using System;
using System.Collections.Generic;

namespace _project.Scripts.Core.SDK.Statuses
{
    public class SDKStatusService : IDisposable
    {
        private readonly Dictionary<SDKTypes, bool> _statuses = new();
        
        public SDKStatus Status { get; private set; }
        
        public event Action<SDKStatus> OnStatusChanged;
        
        public void Initialize()
        {
            SDKStatusCoordinator.OnSDKStateChanged += OnSDKStateChanged;
        }

        public void Dispose()
        {
            SDKStatusCoordinator.OnSDKStateChanged -= OnSDKStateChanged;
        }

        private void OnSDKStateChanged(SDKTypes sdkType, bool isReady)
        {
            _statuses[sdkType] = isReady;

            Status = new SDKStatus
            {
                Firebase = Get(SDKTypes.Firebase),
                AppsFlyer = Get(SDKTypes.AppsFlyer),
                Ads = Get(SDKTypes.Ads)
            };

            OnStatusChanged?.Invoke(Status);
        }

        private bool Get(SDKTypes sdkType)
        {
            return _statuses.TryGetValue(sdkType, out var value) && value;
        }
    }
}