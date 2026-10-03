using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDotSystem : MonoBehaviour
{
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
        Debug.Log(eventData.item.quality);
        RedDotManager.Instance.OnItemAdded(eventData.item);
    }
}
