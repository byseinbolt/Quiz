using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private ScreenChanger _screenChanger;
    
    private void Start()
    {
        _uiController.Initialize();
        _levelController.SetWasSelected += _screenChanger.ShowGameScreen;
        
    }

    private void OnDestroy()
    {
        _levelController.SetWasSelected -= _screenChanger.ShowGameScreen;
    }
}