using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private MockInventoryData mockData;
    private void OnEnable()
    {
        EventBus.Subscribe<ItemObtainedEvent>(OnItemObtained);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<ItemObtainedEvent>(OnItemObtained);
    }
    private void OnItemObtained(ItemObtainedEvent eventData)
    {
        //mockData.Data.items.Add(eventData.item);
        mockData.Data.AddItem(eventData.item);
        Debug.Log(eventData.item.itemName);
    }
}
