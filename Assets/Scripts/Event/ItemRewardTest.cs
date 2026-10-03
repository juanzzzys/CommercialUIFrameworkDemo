using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemRewardTest : MonoBehaviour
{
    [SerializeField]
    private MockInventoryData mockData;

    ItemObtainedEvent itemEvent = new ItemObtainedEvent();
    public void Onclick()
    {
        ItemData testData = new ItemData(305, "Test5", 5, ItemQuality.Common);
        itemEvent.item = testData;
        EventBus.Publish<ItemObtainedEvent>(itemEvent);
    }
}
