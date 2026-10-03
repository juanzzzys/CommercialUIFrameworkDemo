using UnityEngine;

public class MonsterKillTest : MonoBehaviour
{
    public void OnKillMonsterClick()
    {
       // Debug.Log("点击击杀按钮");
        EventBus.Publish<MonsterKilledEvent>(new MonsterKilledEvent());
    }
}