using IngameStateMachine;
using States;
using UnityEngine;
using StartGameState = AIQuiz.Scripts.StartGameModule.StartGameState;

namespace AIQuiz.Scripts
{
    public class TestGameController : MonoBehaviour
    {
        private StateMachine _stateMachine;
        
        private void Awake()
        {
            var states = new IState[]
            {
                GetComponent<GameState>(),
                GetComponent<StartGameState>()
            };
            _stateMachine = new StateMachine(states);
            _stateMachine.Enter<StartGameState>();
        }
        
    }
}