using Chess.Data;
using Chess.Game.States;
using Chess.Game.Views;
using UnityEngine;

namespace Chess.Game
{
    public class DefaultGameMode : MonoBehaviour
    {
        [SerializeField] private GameModeView _gameModeView;
        [SerializeField] private GLTFast.GltfAsset _gltfAsset;
        [SerializeField] private Transform _markerTransform;

        [Header("States")] 
        private WaitingForMarker _waitingForMarker; 
        private LoadingGeometry _loadingGeometry;
        private GeometryPlaced _geometryPlaced;

        private void OnEnable()
        {
            _waitingForMarker.StateCompleted += HandleWaitingForMarkerOnStateCompleted; 
            _loadingGeometry.StateCompleted += HandleLoadingGeometryOnStateCompleted;
            _geometryPlaced.StateCompleted += HandleGeometryPlacedOnStateCompleted;
        }

        private void OnDisable()
        {
            _waitingForMarker.StateCompleted -= HandleWaitingForMarkerOnStateCompleted; 
            _loadingGeometry.StateCompleted -= HandleLoadingGeometryOnStateCompleted;
            _geometryPlaced.StateCompleted -= HandleGeometryPlacedOnStateCompleted;
        }

        public void Init(GameConfig gameConfig, MessagesConfig messagesConfig)
        {
            _gameModeView.InitMessages(messagesConfig);
        }

        public void StartGame()
        {
            _waitingForMarker.ActivateState();
            _gameModeView.ShowState(GameStateName.WaitingForMarker);
        }

        private void HandleWaitingForMarkerOnStateCompleted()
        {
            _gameModeView.ShowState(GameStateName.LoadingGeometry);
            _waitingForMarker.DeactivateState();
            _loadingGeometry.ActivateState();
        }

        private void HandleLoadingGeometryOnStateCompleted()
        {
            _gameModeView.ShowState(GameStateName.GeometryPlaced);
            _loadingGeometry.DeactivateState();
            _geometryPlaced.ActivateState();
        }

        private void HandleGeometryPlacedOnStateCompleted()
        {
            _geometryPlaced.DeactivateState();
        }
    }
}