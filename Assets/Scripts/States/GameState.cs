using FSM;
using UI;

namespace States
{
    public class GameState : StateBase
    {
        private readonly GameScreen _gameScreen;
        private readonly LevelController _levelController;
    
        public GameState(GameScreen gameScreen, LevelController levelController) : base(needsExitTime: false)
        {
            _gameScreen = gameScreen;
            _levelController = levelController;
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