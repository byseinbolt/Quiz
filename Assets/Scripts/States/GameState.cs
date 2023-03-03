using IngameStateMachine;
using UI;
using UnityEngine;

namespace States
{
    public class GameState : MonoBehaviour, IState
    {
        [SerializeField]
        private GameScreen _gameScreen;

        [SerializeField]
        private LevelController _levelController;
        
        public  void OnEnter()
        {
            _gameScreen.Show();
            _levelController.StartLevel();
        }

        public  void OnExit()
        {
            _gameScreen.Hide();
        }
    }
}