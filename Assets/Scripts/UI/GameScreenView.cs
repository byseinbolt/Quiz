using GameData;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreenView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _goalLabel;
        
       [UsedImplicitly]
        // когда спавн закончился (через UnityEvent)
        public void SetGoal(string goalItemName)
        {
            _goalLabel.text = $"Find {goalItemName}";
        }
    }
}