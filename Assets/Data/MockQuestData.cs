using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockQuestData : MonoBehaviour
{

    public QuestData Data { get; private set; }
    = new QuestData(1, "KillMonster", 10);
}
