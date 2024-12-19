using System;
using UnityEngine;

namespace Chess
{
    public class GameInputManager : MonoBehaviour
    {
        private int _mouseButtonId = -1;
        
        public static event Action MouseButtonClicked;

        private void Update()
        {
            if (_mouseButtonId < 0)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(_mouseButtonId))
            {
                MouseButtonClicked?.Invoke();
            }
        }

        public void InitMouseClick(int mouseId) => _mouseButtonId = mouseId;
    }
}
