using GameData;
using JetBrains.Annotations;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameSetData[] _gameSetData;
    
    private CellSpawner _cellSpawner;
    
    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
    }
    
    [UsedImplicitly]
    // при клике на набор
    public void Initialize(GameSetData selectedGameSet)
    {
        // здесь теперь мы просто инициализируем CellSpawner
        _cellSpawner.Initialize(selectedGameSet);
    }
   
    

    private void OnCellClicked(Cell cell)
    {
        
    }

    private void OnDestroy()
    {
  //      _cellSpawner.OnClicked -= OnCellClicked;
    }
}