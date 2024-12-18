using System;
using System.Linq;
using Chess.Data;
using Cysharp.Threading.Tasks;
using GLTFast;
using UnityEngine;

namespace Chess.Game.States
{
    public class GeometryPlaced : GameState
    {
        private readonly Transform _markerTransform;
        private readonly string _markerTargetFigureName;
        private readonly string _spawnObjectName;
        private readonly string _cantFindPivotObjectMessage;
        private readonly string _sceneCantBeLoadedMessage;

        private GltfImport _gltfImport;
        private Transform _targetPivot;

        public GeometryPlaced(Transform markerTransform, GameConfig gameConfig, MessagesConfig messagesConfig)
        {
            _markerTargetFigureName = gameConfig.PivotObjectName;
            _spawnObjectName = gameConfig.SpawnObjectName;
            
            _markerTransform = markerTransform;
            _cantFindPivotObjectMessage = messagesConfig.CantFindPivotObject;
            _sceneCantBeLoadedMessage = messagesConfig.CantFindPivotObject;
        }
        
        public override void ActivateState(object data = null)
        {
            base.ActivateState(data);
            if (data is GltfImport import)
            {
                _gltfImport = import;
            }
            
            SpawnAndRepose();
        }

        private async void SpawnAndRepose()
        {
            await CreateObject();
            UpdateMarkerPosition();
        }

        private async UniTask CreateObject()
        {
            GameObject parentObject = new GameObject(_spawnObjectName);
            bool isLoaded = await _gltfImport.InstantiateSceneAsync(parentObject.transform).AsUniTask();
            if (!isLoaded)
            {
                throw new Exception(_sceneCantBeLoadedMessage);
            }

            _targetPivot = GetTargetPivot(parentObject);
            if (_targetPivot == null)
            {
                throw new NullReferenceException(_cantFindPivotObjectMessage + _markerTargetFigureName);
            }
            
            UpdateModelPosition(parentObject.transform);
        }

        private Transform GetTargetPivot(GameObject parentObject)
        {
            return parentObject.GetComponentsInChildren<Transform>().FirstOrDefault(transform => transform.name == _markerTargetFigureName);
        }

        private void UpdateModelPosition(Transform parentObject)
        {
            Vector3 targetPosition = _markerTransform.position - _targetPivot.position;
            targetPosition.y = parentObject.position.y;
            parentObject.position = targetPosition;
        }

        private void UpdateMarkerPosition()
        {
            Vector3 markerPosition = _markerTransform.position;
            markerPosition.y = _targetPivot.position.y;
            _markerTransform.position = markerPosition;
        }
    }
}