using FSM;
using GameData;
using IngameStateMachine;
using UI;
using UnityEngine;
using StateMachine = IngameStateMachine.StateMachine;

namespace States
{
    public class StartGameState : MonoBehaviour, IState
    {
        [SerializeField]
        private StartScreen _startScreen;

        [SerializeField]
        private DataProvider _dataProvider;

        private bool _isStartGame = true;
        

        public void Initialize(StateMachine stateMachine)
        {
            
        }

        public  void OnEnter()
        {
            _startScreen.Show();
            if (!_isStartGame) return;
            _startScreen.Initialize(_dataProvider.GameSetData);
            _isStartGame = false;


        }

        public  void OnExit()
        {
            _startScreen.Hide();
        }
    }
}