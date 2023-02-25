using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    private ObjectPool<Cell> _pool;
    
    public void CreateObjectPool(Cell cellPrefab, RectTransform parent)
    {
        _pool = new ObjectPool<Cell>(() => Instantiate(cellPrefab, parent));
    }
    
    public Cell GetObject()
    {
        var cell = _pool.Get();
        cell.gameObject.SetActive(true);
        return cell;
    }
    
    public void ReleaseAll(ref List<Cell> cells)
    {
        foreach (var cell in cells)
        {
            cell.gameObject.SetActive(false);
            _pool.Release(cell);
        }

        cells = ListPool<Cell>.Get();
    }
}