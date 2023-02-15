using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreenView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _goalLabel;

        // TODO: решить как пробрасывать цель в этот класс не используя напрямую ссылку на CellSpawner
        [SerializeField]
        private CellSpawner _cellSpawner;

        [UsedImplicitly]
        // когда спавн закончился
        public void SetGoal()
        {
            _goalLabel.text = $"Find {_cellSpawner.GetGoal().ItemName}";
        }
    }
}