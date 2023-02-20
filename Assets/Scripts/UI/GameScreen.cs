using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] 
        private TextMeshProUGUI _goalLabel;
        
        [UsedImplicitly]
       // from UnityEvent in LevelController
       public void SetGoal(string goalItemName)
        {
            _goalLabel.text = $"Find {goalItemName}";
        }

    }
    
}