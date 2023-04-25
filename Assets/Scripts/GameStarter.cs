using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private Button _aiSceneButton;

    [SerializeField]
    private Button _standardSceneButton;

    [SerializeField]
    private Button _exitGameButton;

    private void Awake()
    {
        _aiSceneButton.onClick.AddListener(LoadAIScene);
        _standardSceneButton.onClick.AddListener(LoadStandardScene);
        _exitGameButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        EditorApplication.isPlaying = false;
    }

    private void LoadStandardScene()
    {
        SceneManager.LoadSceneAsync(SceneNames.STANDARD_SCENE);
    }

    private void LoadAIScene()
    {
        SceneManager.LoadSceneAsync(SceneNames.AI_SCENE);
    }
}