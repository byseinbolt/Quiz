using IngameStateMachine;
using UI;
using UnityEngine;

namespace States
{
    public class GameState : MonoBehaviour, IState
    {
        [SerializeField]
        private GameScreen _gameScreen;
        
        public void Initialize(StateMachine stateMachine)
        {
        }

        public  void OnEnter()
        {
            _gameScreen.Show();
        }

        public  void OnExit()
        {
            _gameScreen.Hide();
        }
    }
}