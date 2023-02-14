using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _goalLabel;

    [SerializeField]
    private CellSpawner _cellSpawner;

    [UsedImplicitly]
    // когда спавн закончился
    public void SetGoal()
    {
        _goalLabel.text = $"Find {_cellSpawner.GetGoal()}";
    }
}


