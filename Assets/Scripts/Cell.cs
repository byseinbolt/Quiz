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

    [Header("Background settings")]
    [SerializeField] private float _hueMin;
    [SerializeField] private float _hueMax = 1;
    [SerializeField] private float _saturationMin = 1;
    [SerializeField] private float _saturationMax = 1;
    [SerializeField] private float _valueMin = 1;
    [SerializeField] private float _valueMax = 1;
    [SerializeField] private float _alphaMin = 0.6f;
    [SerializeField] private float _alphaMax = 0.6f;
    
    public void Initialize(Sprite gameItemView)
    {
        _image.sprite = gameItemView;
        _background.color = Random.ColorHSV(_hueMin, _hueMax, _saturationMin, 
            _saturationMax, _valueMin, _valueMax, _alphaMin, _alphaMax);
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