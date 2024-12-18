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

        private GameStateMachine _gameStateMachine;
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
            _gameStateMachine = new GameStateMachine();
            _loadingGeometry = new LoadingGeometry(_gltfAsset, gameConfig.GetAssetPaths(), messagesConfig.CantFindGtlfPath);
            _waitingForMarker = new WaitingForMarker(_markerTransform);
            _geometryPlaced = new GeometryPlaced();
            _gameModeView.InitMessages(messagesConfig);
        }

        public void StartGame()
        {
            _gameStateMachine.ChangeState(_waitingForMarker);
            _gameModeView.ShowState(GameStateName.WaitingForMarker);
        }

        private void HandleWaitingForMarkerOnStateCompleted()
        {
            _gameModeView.ShowState(GameStateName.LoadingGeometry);
            _gameStateMachine.ChangeState(_loadingGeometry);
        }

        private void HandleLoadingGeometryOnStateCompleted()
        {
            _gameModeView.ShowState(GameStateName.GeometryPlaced);
            _gameStateMachine.ChangeState(_geometryPlaced);
        }

        private void HandleGeometryPlacedOnStateCompleted()
        {
            _gameStateMachine.FinishGame();
        }
    }
}