using TMPro;
using UnityEngine;

public class QuestPanel :MonoBehaviour
{
    [SerializeField]
    private MockQuestData mockData;

    [SerializeField]
    private TMP_Text text;
    //public override void OnEnter()
    //{
    //    base.OnEnter();
        
    //}

    private void OnEnable()
    {
        //Debug.Log("QuestPanel OnEnable");
        //Debug.Log("mockData = " + mockData);
        //Debug.Log("mockData.Data = " + mockData?.Data);
        mockData.Data.OnProgressChanged += RefreshUI;

        RefreshUI();
    }

    private void OnDisable()
    {
        mockData.Data.OnProgressChanged -= RefreshUI;
    }

    private void RefreshUI()
    {
        text.text =
            "questId: " + mockData.Data.questId +
            " questName: " + mockData.Data.questName +
            " TargetCount: " + mockData.Data.targetCount +
            " CurrentCount: " + mockData.Data.currentCount;
    }
}