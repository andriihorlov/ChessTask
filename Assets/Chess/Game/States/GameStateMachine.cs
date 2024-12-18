namespace Chess.Game.States
{
    public class GameStateMachine 
    {
        private GameState _currentState;

        public void ChangeState(GameState gameState)
        {
            _currentState?.DeactivateState();
            _currentState = gameState;
            _currentState?.ActivateState();
        }

        public void FinishGame()
        {
            _currentState?.DeactivateState();
        }
    }
}
