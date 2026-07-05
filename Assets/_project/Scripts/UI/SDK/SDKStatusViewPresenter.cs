using _project.Scripts.Core.SDK;
using _project.Scripts.Core.SDK.Statuses;
using UnityEngine;

namespace _project.Scripts.UI.SDK
{
    public class SDKStatusViewPresenter
    {
        private readonly SDKStatusService _statusService;
        private readonly SDKStatusView _statusView;
        
        public SDKStatusViewPresenter(SDKStatusService statusService, SDKStatusView statusView)
        {
            _statusService = statusService;
            _statusView = statusView;
        }

        public void OnEnable()
        {
            _statusService.OnStatusChanged += _statusView.Refresh;
        }

        public void OnDisable()
        {
            _statusService.OnStatusChanged -= _statusView.Refresh;
        }
    }
}