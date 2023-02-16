using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreenView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _goalLabel;

        // TODO: решить как пробрасывать цель в этот класс не используя напрямую ссылку на LevelController
        [SerializeField]
        private LevelController _levelController;
        
        [UsedImplicitly]
        // когда спавн закончился
        public void SetGoal()
        {
            _goalLabel.text = $"Find {_levelController.GoalItem.ItemName}";
        }
    }
}