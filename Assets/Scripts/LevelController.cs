using UnityEngine;

public class LevelController : MonoBehaviour
{
    private CellSpawner _cellSpawner;

    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
    }

    private void Start()
    {
//        _cellSpawner.OnClicked += OnCellClicked;
        _cellSpawner.Spawn();
    }

    private void OnCellClicked(Cell cell)
    {
        
    }

    private void OnDestroy()
    {
  //      _cellSpawner.OnClicked -= OnCellClicked;
    }
}