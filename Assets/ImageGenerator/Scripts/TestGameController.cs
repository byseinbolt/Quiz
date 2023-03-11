using System;
using IngameStateMachine;
using States;
using UnityEngine;

namespace ImageGenerator
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