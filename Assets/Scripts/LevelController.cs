using System;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public event Action SetWasSelected;
    [SerializeField]
    private StartScreenView _startScreenView;
    
    private CellSpawner _cellSpawner;
    private GameSetData _selectedGameSet;
    
    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
    }

    private void Start()
    {
        _startScreenView.OnInstanceClicked += OnGameSetInstanceClicked;
    }

    private void OnGameSetInstanceClicked(GameSetInstance setInstance)
    {
        _selectedGameSet = setInstance.GameSetData;
        SetWasSelected?.Invoke();
        Initialize();
    }
    
    private void Initialize()
    {
        _cellSpawner.Initialize(_selectedGameSet);
    }
   
    

    private void OnCellClicked(Cell cell)
    {
        
    }

    private void OnDestroy()
    {
        _startScreenView.OnInstanceClicked -= OnGameSetInstanceClicked;
  //      _cellSpawner.OnClicked -= OnCellClicked;
    }
}