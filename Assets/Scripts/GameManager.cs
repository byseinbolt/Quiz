using GameData;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameSetData[] _gameSetsData;

    [SerializeField]
    private GameObject _gamePlane;

    [SerializeField]
    private GameObject _startScreen;

    [UsedImplicitly]
    // при клике на набор
    public void ShowGamePlane()
    {
        _startScreen.SetActive(false);
        _gamePlane.SetActive(true);
        
    }

}
