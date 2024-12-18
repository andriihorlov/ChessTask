namespace Chess.Game.States
{
    public class GameStateMachine 
    {
        private GameState _currentState;

        public void ChangeState(GameState gameState, object data = null)
        {
            _currentState?.DeactivateState();
            _currentState = gameState;
            _currentState?.ActivateState(data);
        }

        public void FinishGame()
        {
            _currentState?.DeactivateState();
        }
    }
}
