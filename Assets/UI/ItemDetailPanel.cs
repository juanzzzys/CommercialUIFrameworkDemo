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

    public void SetData(ItemData item)
    {
        

        itemNameText.text = item.itemName;
        itemCountText.text = item.count.ToString();
        itemQualityText.text = item.quality.ToString();
    }

}