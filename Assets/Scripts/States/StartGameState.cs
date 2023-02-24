using FSM;
using GameData;
using UI;

namespace States
{
    public class StartGameState : StateBase
    {
        private readonly StartScreen _startScreen;
        private readonly DataProvider _dataProvider;
        private int _oneInitializeForGame;
    
        public StartGameState(StartScreen startScreen, DataProvider dataProvider) : base(needsExitTime: false)
        {
            _startScreen = startScreen;
            _dataProvider = dataProvider;
        }

        //TODO : временная костыль, что бы не спавнились новые иконки в начале игры, подумать как сделать лучше 
        public override void OnEnter()
        {
            _startScreen.Show();
            if (_oneInitializeForGame < 1)
            {
                _startScreen.Initialize(_dataProvider.GameSetData);
                _oneInitializeForGame++;
            }
            //_startScreen.Initialize(_dataProvider.GameSetData);
        }

        public override void OnExit()
        {
            _startScreen.Hide();
        }
    }
}