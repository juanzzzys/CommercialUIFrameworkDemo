using UnityEngine;

public class ItemCellTest : MonoBehaviour
{
    [SerializeField]
    private MockInventoryData mockInventoryData;

    public void TestAddItem()
    {
        mockInventoryData.Data.AddItem(
            new ItemData(301, "测试物品", 1, ItemQuality.Common)
        );
                mockInventoryData.Data.AddItem(
            new ItemData(302, "测试物品", 1, ItemQuality.Common)
        );
                mockInventoryData.Data.AddItem(
            new ItemData(303, "测试物品", 2, ItemQuality.Rare)
        );
    }
}