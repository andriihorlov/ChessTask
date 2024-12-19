using System;

namespace Chess.Game.States
{
    public abstract class GameState 
    {
        public event Action StateCompleted;

        public virtual void ActivateState(object data = null)
        {
        }

        public virtual void DeactivateState()
        {
        }

        protected void CompleteStep()
        {
            StateCompleted?.Invoke();
        }
    }
}