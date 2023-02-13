using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Item[] _items;
    
    public Image Image { get => _image; }
    
    public Item[] Items { get => _items; }
    
}