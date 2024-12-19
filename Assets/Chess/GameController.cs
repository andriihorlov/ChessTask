using Chess.Data;
using Chess.Game;
using UnityEngine;

namespace Chess
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private DefaultGameMode _defaultGameMode;
        [SerializeField] private GameInputManager _inputManager;
        [Space]
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private MessagesConfig _messagesConfig;

        private void Awake()
        {
            _defaultGameMode.Init(_gameConfig, _messagesConfig);
            _inputManager.InitMouseClick(_gameConfig.MouseButtonId);
        }

        private void Start()
        {
            _defaultGameMode.StartGame();
        }
    }
}