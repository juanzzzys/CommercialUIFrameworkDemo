using System.Collections.Generic;
using System;


public class InventoryData{
    public List<ItemData> items=new List<ItemData>();
    
    public event Action<ItemData> OnItemAdded;
    public void AddItem(ItemData item)
    {
    items.Add(item);
    OnItemAdded?.Invoke(item);
    }

}
