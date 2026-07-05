using _project.Scripts.Core.SDK.Statuses;
using Firebase;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Firebase
{
    public class FirebaseBootstrap
    {
        public async void Initialize()
        {
            var status = await FirebaseApp.CheckAndFixDependenciesAsync();

            bool isReady = status == DependencyStatus.Available;

            Debug.Log($"Firebase: {(isReady ? "READY" : "FAILED")}");

            SDKStatusCoordinator.ReportState(SDKTypes.Firebase, isReady);
        }
    }
}