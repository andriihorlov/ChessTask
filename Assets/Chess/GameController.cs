using Chess.Game;
using UnityEngine;

namespace Chess
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private DefaultGameMode _defaultGameMode;
        [SerializeField] private GameInputManager _inputManager;

        private void Start()
        {
            _defaultGameMode.StartGame();
        }
    }
}