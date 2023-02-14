using GameData;
using JetBrains.Annotations;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private CellSpawner _cellSpawner;
    [SerializeField]
    private GameSetData[] _gameSetData;

    [UsedImplicitly]
    // при клике на набор
    public void Initialize(GameSetData selectedGameSet)
    {
        _cellSpawner.Initialize(selectedGameSet);
        _cellSpawner.Spawn();
    }
    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
    }
    

    private void OnCellClicked(Cell cell)
    {
        
    }

    private void OnDestroy()
    {
  //      _cellSpawner.OnClicked -= OnCellClicked;
    }
}