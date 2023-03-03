using FSM;
using IngameStateMachine;
using UI;
using UnityEngine;
using StateMachine = IngameStateMachine.StateMachine;

namespace States
{
    public class LevelCompletedState : MonoBehaviour, IState
    {
        [SerializeField]
        private LevelCompletedScreen _levelCompletedScreen;
        
        public void Initialize(StateMachine stateMachine)
        {
        }

        public void OnEnter()
        {
            _levelCompletedScreen.Show();
            _levelCompletedScreen.ShowNextLevelButton();
        }

        public void OnExit()
        {
            _levelCompletedScreen.Hide();
        }
    }
}