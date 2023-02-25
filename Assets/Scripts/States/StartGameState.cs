using FSM;
using GameData;
using UI;

namespace States
{
    public class StartGameState : StateBase
    {
        private readonly StartScreen _startScreen;
        
        public StartGameState(StartScreen startScreen, DataProvider dataProvider) : base(needsExitTime: false)
        {
            _startScreen = startScreen;
            _startScreen.Initialize(dataProvider.GameSetData);
        }
        
        public override void OnEnter()
        {
            _startScreen.Show();
        }

        public override void OnExit()
        {
            _startScreen.Hide();
        }
    }
}