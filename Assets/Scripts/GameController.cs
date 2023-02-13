using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvasForCells;
    [SerializeField]
    private ItemHolder _itemHolder;
    
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_itemHolder.gameObject, _canvasForCells.transform);
            _itemHolder.Image.sprite = _itemHolder.GameSet.GameItemViews[i];
        }
    }
}
