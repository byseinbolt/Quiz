using System;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Cell : MonoBehaviour
{
    public Image Image => _image;
    
    [SerializeField]
    private Image _image;
    
    [SerializeField]
    private Image _background;
    
    [SerializeField]
    private ColorProvider _colorProvider;
    private Action<Cell> _onClicked;
    
    public void Initialize(Sprite gameItemView)
    {
        _image.sprite = gameItemView;
        _background.color = _colorProvider.GetRandomColor();
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