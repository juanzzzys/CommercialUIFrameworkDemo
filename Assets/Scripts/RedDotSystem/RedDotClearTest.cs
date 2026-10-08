using UnityEngine;

public class RedDotClearTest : MonoBehaviour
{
    public void OnClearRedDotClick()
    {
        EventBus.Publish(new ItemViewedEvent());
    }
}