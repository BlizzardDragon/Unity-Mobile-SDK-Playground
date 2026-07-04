using System.Collections.Generic;
using UnityEngine;
using _project.Scripts.Core.SDK;

namespace _project.Scripts.Core
{
    public class SDKManager : MonoBehaviour
    {
        public static SDKManager Instance { get; private set; }

        public SDKStatus Status { get; private set; }

        public static event System.Action<SDKStatus> OnStatusChanged;

        private Dictionary<string, bool> _states = new();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            SDKCoordinator.OnSDKStateChanged += OnSDKStateChanged;
        }

        private void OnDestroy()
        {
            SDKCoordinator.OnSDKStateChanged -= OnSDKStateChanged;
        }

        private void OnSDKStateChanged(string sdk, bool isReady)
        {
            _states[sdk] = isReady;

            Status = new SDKStatus
            {
                Firebase = Get("Firebase"),
                AppsFlyer = Get("AppsFlyer"),
                Ads = Get("Ads")
            };

            OnStatusChanged?.Invoke(Status);
        }

        private bool Get(string key)
        {
            return _states.TryGetValue(key, out var value) && value;
        }
    }
}