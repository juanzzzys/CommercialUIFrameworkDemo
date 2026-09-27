using UnityEngine;
using System.Collections.Generic;

public class ItemCellPool : MonoBehaviour
{
    [SerializeField] private ItemCell itemCellPrefab;

    private Queue<ItemCell> pool = new Queue<ItemCell>();

    public ItemCell Get()
    {
        if (pool.Count > 0)
        {
            ItemCell itemCell=pool.Dequeue();
            itemCell.gameObject.SetActive(true);
            return itemCell;
        }

        return Instantiate(itemCellPrefab);
    }

    public void Release(ItemCell itemCell)
    {
        itemCell.gameObject.SetActive(false);
        pool.Enqueue(itemCell);
    }
}