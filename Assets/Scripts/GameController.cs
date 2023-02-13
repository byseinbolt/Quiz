using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private ItemHolder _itemHolder;

    [SerializeField]
    private GameObject _PrefabCell;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_PrefabCell, transform);
        }
    }
}
