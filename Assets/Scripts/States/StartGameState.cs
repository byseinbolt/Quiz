using GameData;
using IngameStateMachine;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States
{
    public class StartGameState : MonoBehaviour, IState
    {
        [SerializeField]
        private StartScreen _startScreen;

        [SerializeField]
        private DataProvider _dataProvider;

        private bool _isStartGame = true;
        
        public  void OnEnter()
        {
            _startScreen.Show();
            _startScreen.ExitButton.onClick.AddListener(LoadStartScene);

            if (_isStartGame)
            {
                _startScreen.Initialize(_dataProvider.GameSetData);
                _isStartGame = false;
            }
        }

        private void LoadStartScene()
        {
            SceneManager.LoadSceneAsync(SceneNames.START_SCENE);
        }

        public  void OnExit()
        {
            _startScreen.Hide();
        }
    }
}