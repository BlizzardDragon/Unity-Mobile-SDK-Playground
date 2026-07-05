using _project.Scripts.Core.SDK;
using TMPro;
using UnityEngine;

namespace _project.Scripts.UI.SDK
{
    public class SDKStatusView : MonoBehaviour
    {
        [Header("Status")]
        [SerializeField] private TMP_Text _firebaseStatus;
        [SerializeField] private TMP_Text _appsFlyerStatus;
        [SerializeField] private TMP_Text _adsStatus;
        [SerializeField] private TMP_Text _globalStatus;

        public void Refresh(SDKStatus status)
        {
            SetStatusText(_firebaseStatus, "Firebase", status.Firebase);
            SetStatusText(_appsFlyerStatus, "AppsFlyer", status.AppsFlyer);
            SetStatusText(_adsStatus, "Ads", status.Ads);

            _globalStatus.text = status.AllReady ? "ALL SYSTEMS READY" : "INITIALIZING...";
            _globalStatus.color = status.AllReady ? Color.green : Color.red;
        }

        private void SetStatusText(TMP_Text textComponent, string label, bool isReady)
        {
            string statusColor = isReady ? "green" : "red";
            string statusText = isReady ? "READY" : "OFF";
            textComponent.text = $"<color=#FFFFFF>{label}:</color> <color={statusColor}>{statusText}</color>";
        }
    }
}