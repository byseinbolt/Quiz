using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabCell;
    [SerializeField] 
    private ItemHolder _itemHolder;
    [SerializeField]
    private TextMeshProUGUI _desiredGoalLabel;

    private void Start()
    {
        for (int i = 0; i <3; i++)
        {
            Instantiate(_prefabCell, transform);
            _itemHolder.Image.sprite = _itemHolder.GameSet.GameItemViews[i];
        }
        
    }
}