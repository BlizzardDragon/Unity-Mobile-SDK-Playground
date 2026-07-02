using Firebase;
using UnityEngine;

namespace _project.Scripts.Core
{
    public class FirebaseBootstrap : MonoBehaviour
    {
        public static bool IsReady { get; private set; }

        private async void Awake()
        {
            var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync();

            if (dependencyStatus == DependencyStatus.Available)
            {
                IsReady = true;
                Debug.Log("Firebase ready");
            }
            else
            {
                Debug.LogError($"Firebase init failed: {dependencyStatus}");
            }
        }
    }
}