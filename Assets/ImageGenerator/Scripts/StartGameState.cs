using System;
using IngameStateMachine;
using UnityEngine;

namespace ImageGenerator
{
    public class StartGameState : MonoBehaviour, IState
    {
        [SerializeField]
        private StartScreen _startScreen;

        [SerializeField]
        private AICommandSender _aiCommandSender;
        
        public void OnEnter()
        {
            _startScreen.Show();
        }

        public void OnExit()
        {
           _startScreen.Hide();
        }
    }
}