using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private ItemHolder _itemHolder;

    [SerializeField]
    private GameObject _prefabCell;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_prefabCell, transform);
        }
    }
}
