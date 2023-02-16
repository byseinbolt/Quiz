using System;
using GameData;
using UI;
using UnityEngine;
public class StartScreenController : MonoBehaviour
{
    //подумать над названием ивента
    public event Action<GameSetView> OnInstanceClicked;
        
    [SerializeField] 
    private GameSetView gameSetViewPrefab;
    
    [SerializeField]
    private Transform _iconSpawnPosition;
    
    public void Initialize(GameSetData[] gameSetsData)
    {
        foreach (var gameSetData in gameSetsData)
        {
            var gameSetIconInstance = Instantiate(gameSetViewPrefab, _iconSpawnPosition);
            gameSetIconInstance.SetClickCallback(value => OnInstanceClicked?.Invoke(value));
            gameSetIconInstance.Initialize(gameSetData);
        }
    }
}
