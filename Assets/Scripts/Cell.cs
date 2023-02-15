using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Image _background;
    
    
    
    private Action<Cell> _onClicked;

    public void Initialize(Sprite gameItemView)
    {
        _image.sprite = gameItemView;
        _background.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 0.6f, 0.6f);
    }

    public void Click()
    {
        _onClicked?.Invoke(this);
    }
    public void SetClickCallback(Action<Cell> onClicked)
    {
        _onClicked = onClicked;
    }
}