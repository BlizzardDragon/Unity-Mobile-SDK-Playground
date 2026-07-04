using _project.Scripts.Core.SDK;
using UnityEngine;

namespace _project.Scripts.UI.SDK
{
    public class SDKStatusViewPresenter : MonoBehaviour
    {
        [SerializeField] private SDKStatusService _statusService;
        [SerializeField] private SDKStatusView _statusView;
        
        private void OnEnable()
        {
            _statusService.OnStatusChanged += _statusView.Refresh;
        }

        private void OnDisable()
        {
            _statusService.OnStatusChanged -= _statusView.Refresh;
        }
    }
}