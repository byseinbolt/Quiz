using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Item[] _items;

    private void Start()
    {
        _image.sprite = _items[1].Sprite;
    }
}