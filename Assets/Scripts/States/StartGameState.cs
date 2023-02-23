using FSM;
using GameData;
using UI;

namespace States
{
    public class StartGameState : StateBase
    {
        private readonly StartScreen _startScreen;
        private readonly DataProvider _dataProvider;
    
        public StartGameState(StartScreen startScreen, DataProvider dataProvider) : base(needsExitTime: false)
        {
            _startScreen = startScreen;
            _dataProvider = dataProvider;
        }

        public override void OnEnter()
        {
            _startScreen.Show();
            _startScreen.Initialize(_dataProvider.GameSetData);
        }

        public override void OnExit()
        {
            _startScreen.Hide();
        }
    }
}