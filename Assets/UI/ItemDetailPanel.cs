using UnityEngine;

using TMPro;
using System;
public class ItemDetailPanel : BasePanel
{
    
    [SerializeField]
   private TMP_Text itemNameText;
   [SerializeField]
   private TMP_Text itemCountText;
   [SerializeField]
   private TMP_Text itemQualityText;
   //private ItemData item;


    public void SetData(ItemData item)
    {
        //this.item=item;

        itemNameText.text = item.itemName;
        itemCountText.text = item.count.ToString();
        itemQualityText.text = item.quality.ToString();
    }
    public override void OnExit(){
        base.OnExit();
       RedDotManager.Instance.RefreshInventoryRedDot();
    }
    // public void OnClickBack()
    // {
    //     Debug.Log("点击了详情返回按钮");
    //     UIManager.Instance.ClosePanel<ItemDetailPanel>();
    // }

}