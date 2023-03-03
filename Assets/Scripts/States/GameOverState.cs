using UI;
using IngameStateMachine;
using UnityEngine;
using StateMachine = IngameStateMachine.StateMachine;

namespace States
{
    public class GameOverState : MonoBehaviour, IState
    {
        [SerializeField]
        private LevelCompletedScreen _levelCompletedScreen;
        
        public void Initialize(StateMachine stateMachine)
        {
        }

        public  void OnEnter()
        {
            _levelCompletedScreen.Show();
            _levelCompletedScreen.ShowRestartView();
        }

        public void OnExit()
        {
            _levelCompletedScreen.Hide();
        }
        
    }
}