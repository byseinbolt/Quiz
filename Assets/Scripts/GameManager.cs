using GameData;
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

    [SerializeField]
    private DataProvider _dataProvider;

    private void Start()
    {
        _uiController.Initialize(_dataProvider);
        _levelController.Initialize(_dataProvider);
        _levelController.SetWasSelected += _screenChanger.ShowGameScreen;
        _levelController.LevelCompleted += _screenChanger.ShowGameOverScreen;
    }

    private void OnDestroy()
    {
        _levelController.SetWasSelected -= _screenChanger.ShowGameScreen;
        _levelController.LevelCompleted -= _screenChanger.ShowGameOverScreen;
    }
}