using Firebase;
using UnityEngine;

namespace _project.Scripts.Core.SDK.Firebase
{
    public class FirebaseBootstrap : MonoBehaviour
    {
        private async void Awake()
        {
            var status = await FirebaseApp.CheckAndFixDependenciesAsync();

            bool isReady = status == DependencyStatus.Available;

            Debug.Log($"Firebase: {(isReady ? "READY" : "FAILED")}");

            SDKCoordinator.ReportState("Firebase", isReady);
        }
    }
}