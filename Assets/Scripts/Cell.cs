using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image Image => _image;
    [SerializeField]
    private Image _image;

    private Action<Cell> _onClicked;

    public void Click()
    {
        _onClicked?.Invoke(this);
    }
    public void SetClickCallback(Action<Cell> onClicked)
    {
        _onClicked = onClicked;
    }
}