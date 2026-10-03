using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任务系统
/// </summary>
public class QuestSystem : MonoBehaviour
{

    [SerializeField]
    MockQuestData mockData;

    private void OnEnable()
    {
        Debug.Log("QuestSystem OnEnable");

        EventBus.Subscribe<MonsterKilledEvent>(OnMonsterKilled);

        Debug.Log("QuestSystem 订阅完成");
    }

    private void OnDisable()
    {
        Debug.Log("QuestSystem OnDisable");

        EventBus.UnSubscribe<MonsterKilledEvent>(OnMonsterKilled);
    }

    private void OnMonsterKilled(MonsterKilledEvent eventData)
    {
        Debug.Log("QuestSystem 收到 MonsterKilledEvent");

        mockData.Data.AddProgress();

        Debug.Log("CurrentCount = " + mockData.Data.currentCount);
    }
}
