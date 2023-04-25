using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private Button _aiSceneButton;
    
    [SerializeField]
    private Button _standardSceneButton;

    private void Awake()
    {
        _aiSceneButton.onClick.AddListener(LoadAIScene);
        _standardSceneButton.onClick.AddListener(LoadStandardScene);
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