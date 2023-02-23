using FSM;
using UI;

namespace States
{
    public class GameOverState : StateBase
    {
        private LevelCompletedScreen _levelCompletedScreen;
        
        public GameOverState(LevelCompletedScreen levelCompletedScreen) : base(needsExitTime: false)
        {
            _levelCompletedScreen = levelCompletedScreen;
        }

        public override void OnEnter()
        {
            _levelCompletedScreen.Show();
            _levelCompletedScreen.ShowRestartView();
        }

        public override void OnExit()
        {
            _levelCompletedScreen.Hide();
        }
    }
}