using FSM;
using UI;

namespace States
{
    public class LevelCompletedState : StateBase
    {
        private readonly LevelCompletedScreen _levelCompletedScreen;
        
        public LevelCompletedState(LevelCompletedScreen levelCompletedScreen) : base(needsExitTime: false)
        {
            _levelCompletedScreen = levelCompletedScreen;
        }

        public override void OnEnter()
        {
            _levelCompletedScreen.Show();
            _levelCompletedScreen.ShowNextLevelButton();
        }

        public override void OnExit()
        {
            _levelCompletedScreen.Hide();
        }
    }
}