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
            _firebaseStatus.text = status.Firebase ? "Firebase: READY" : "Firebase: OFF";
            _appsFlyerStatus.text = status.AppsFlyer ? "AppsFlyer: READY" : "AppsFlyer: OFF";
            _adsStatus.text = status.Ads ? "Ads: READY" : "Ads: OFF";

            _globalStatus.text = status.AllReady ? "ALL SYSTEMS READY" : "INITIALIZING...";
        }
    }
}