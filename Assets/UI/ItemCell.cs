using UnityEngine;
using TMPro;
using System;
public class ItemCell:MonoBehaviour

{
    [SerializeField]
   private TMP_Text itemNameText;
   [SerializeField]
   private TMP_Text itemCountText;
   [SerializeField]
   private TMP_Text itemQualityText;
   [SerializeField]
   private RedDotUI redDotUI;

   private ItemData itemData;
   public event Action<ItemData> Onclicked;

public void SetData(ItemData item)
{
    itemData = item;
    Debug.Log($"ItemCell 收到数据：{item.itemName}");
    itemNameText.text = item.itemName;
    itemCountText.text = item.count.ToString();
    itemQualityText.text = item.quality.ToString();
}
public void Onclick(){
   Debug.Log(itemData.itemName);
    Onclicked?.Invoke(itemData);

}
public void RefreshRedDot(){
    if(itemData==null||redDotUI==null){
        return;
    }
    bool isNew=RedDotManager.Instance.IsItemNew(itemData.id);
    if(isNew){
        redDotUI.Show();
    }
    else{
        redDotUI.Hide();
    }
}

}