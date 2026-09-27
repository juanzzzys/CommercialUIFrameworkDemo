using UnityEngine;
public class ItemCellTest:MonoBehaviour{
    [SerializeField]
   private MockInventoryData mockInventoryData;
   [SerializeField]
   private ItemCell itemCell;



   void Start(){
   Debug.Log("ItemCellTest Start 执行了");

        itemCell.SetData(mockInventoryData.Data.items[0]);

        Debug.Log("SetData 执行完成");

   }
}
