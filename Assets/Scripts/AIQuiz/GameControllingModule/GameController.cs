using UnityEngine;

namespace AIQuiz.GameControllingModule
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private ImageSpawner _imageSpawner;
        
        [SerializeField] 
        private GameScreen _gameScreen;

        [SerializeField] 
        private GoalSelector _goalSelector;
        
        private void Awake()
        {
            _imageSpawner.ImageClicked += OnImageClicked;
            _imageSpawner.SpawnCompleted += OnSpawnCompleted;
            _gameScreen.HideItemsRequest += _imageSpawner.HidePreviousImages;
        }
        
        private void OnSpawnCompleted()
        {
            _gameScreen.Show();
            _gameScreen.SetGoal(_goalSelector.Goal);
        }

        private void OnImageClicked(DallEItem item)
        {
            if (item.Name == _goalSelector.Goal)
            {
                _gameScreen.OnGoalItemClicked(item);
            }
            else
            {
                _gameScreen.OnWrongItemClicked(item);
            }
        }
    }
}