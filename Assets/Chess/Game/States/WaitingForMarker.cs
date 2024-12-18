using UnityEngine;

namespace Chess.Game.States
{
    public class WaitingForMarker : GameState
    {
        private readonly Transform _markerTransform;
        private readonly Camera _mainCamera;

        public WaitingForMarker(Transform markerTransform)
        {
            _markerTransform = markerTransform;
            SetActiveMarker(false);
            _mainCamera = Camera.main;
        }

        public override void ActivateState()
        {
            base.ActivateState();
            GameInputManager.MouseButtonClicked += HandleGameInputManagerMouseButtonClicked;
        }

        public override void DeactivateState()
        {
            base.DeactivateState();
            GameInputManager.MouseButtonClicked -= HandleGameInputManagerMouseButtonClicked;
        }

        private void HandleGameInputManagerMouseButtonClicked()
        {
            GameInputManager.MouseButtonClicked -= HandleGameInputManagerMouseButtonClicked;
            SpawnMarker();
        }

        private void SpawnMarker()
        {
            UpdateMarkerPosition();
            SetActiveMarker(true);
            CompleteStep();
        }

        private void UpdateMarkerPosition()
        {
            Ray screenRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(screenRay, out RaycastHit hitInfo))
            {
                return;
            }

            Vector3 targetPosition = hitInfo.point;
            targetPosition.y += hitInfo.collider.bounds.extents.y;
            _markerTransform.position = targetPosition;
        }

        private void SetActiveMarker(bool isActive)
        {
            _markerTransform.gameObject.SetActive(isActive);
        }
    }
}