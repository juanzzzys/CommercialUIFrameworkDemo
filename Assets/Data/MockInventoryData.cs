using UnityEngine;
public class MockInventoryData:MonoBehaviour
{
    private InventoryData inventoryData;
    public InventoryData Data => inventoryData;
    private void Awake()
    {
    inventoryData=new InventoryData();
    for (int i = 1; i <= 300; i++)
    {
        if(i<=50){
 inventoryData.items.Add(new ItemData(i, "Item" + i, 50, ItemQuality.Common));
        }
        else if(i>50&&i<=150){
             inventoryData.items.Add(new ItemData(i, "Item" + i, 100, ItemQuality.Uncommon));
        }
        else if(i>150&&i<=250){
            if(i>150&&i<=200){
                inventoryData.items.Add(new ItemData(i, "Item" + i, 50, ItemQuality.Rare));

            }
            else if(i>200&&i<=220){
                 inventoryData.items.Add(new ItemData(i, "Item" + i, 30, ItemQuality.Rare));

            }
            else{
                 inventoryData.items.Add(new ItemData(i, "Item" + i, 100, ItemQuality.Rare));
            }
            

        }
        else{
             inventoryData.items.Add(new ItemData(i, "Item" + i, 50, ItemQuality.Epic));
        }
       
    }
    
    }
    // void Start(){
    //     foreach(ItemData item in inventoryData.items){
    //         Debug.Log("物品ID: " + item.id + " 物品名称: " + item.itemName + " 物品数量: " + item.count + " 物品品质: " + item.quality);
    //     }
    // }
}