using UnityEngine;

public class RedDotTest : MonoBehaviour
{
    public void OnTestRedDot()
    {
        ItemData testItem =
            new ItemData(999, "红点测试物品", 1, ItemQuality.Rare);

        ItemObtainedEvent eventData = new ItemObtainedEvent();
        eventData.item = testItem;

        EventBus.Publish(eventData);
    }
}