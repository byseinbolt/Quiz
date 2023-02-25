using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image Image => _image;
    
    [SerializeField]
    private Image _image;
    
    [SerializeField]
    private Image _background;
    
    [SerializeField]
    private BackgroundSettingsCell _backgroundCell;
    private Action<Cell> _onClicked;
    
    public void Initialize(Sprite gameItemView)
    {
        _image.sprite = gameItemView;
        _background.color = _backgroundCell.CustomBackground();
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