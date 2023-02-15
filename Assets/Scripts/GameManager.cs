using System;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private LevelController _levelController;

    private void Start()
    {
        _uiController.Initialize();
    }
}