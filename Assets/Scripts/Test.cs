using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabCell;

    [SerializeField] 
    private ItemHolder _itemHolder;

    private void Start()
    {
        for (int i = 0; i <3; i++)
        {
            Instantiate(_prefabCell, transform);
            _itemHolder.Image.sprite = _itemHolder.Items[0].Sprite[i];
        }
        
    }
}
