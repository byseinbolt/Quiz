using FSM;
using UI;

namespace States
{
    public class GameState : StateBase
    {
        private readonly GameScreen _gameScreen;

        public GameState(GameScreen gameScreen) : base(needsExitTime: false)
        {
            _gameScreen = gameScreen;
        }

        public override void OnEnter()
        {
            _gameScreen.Show();
        }

        public override void OnExit()
        {
            _gameScreen.Hide();
        }
    }
}