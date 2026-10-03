
using System;

/// <summary>
/// 任务数据
/// </summary>
public class QuestData 
{
    public int questId;
    public string questName;
    public int targetCount;
    public int currentCount;

    public event Action OnProgressChanged;
    public QuestData(int questId, string questName, int targetCount)
    {
        this.questId = questId;
        this.questName = questName;
        this.targetCount = targetCount;
        this.currentCount = 0;
    }
    public void AddProgress()
    {
        if (currentCount >= targetCount)
        {
            return;
        }

        currentCount += 1;
        OnProgressChanged?.Invoke();
    }
}
