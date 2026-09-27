using UnityEngine;
using System.Collections.Generic;

public class InventoryPanel : BasePanel
{
    // [SerializeField]
    // private ItemCell itemCellPrefab;
    [SerializeField]
    private MockInventoryData mockData;
    [SerializeField] private VirtualItemList virtualItemList;
    private List<ItemData> currentList = new List<ItemData>();
    private ItemQuality currentQuality;
    private bool sortByCountDescending=false ;
    public override void OnEnter()
    {
        base.OnEnter();
        currentQuality = ItemQuality.All;
         RefreshList();

    }

    private void OnEnable()
    {
        if (virtualItemList != null)
        {
            virtualItemList.OnItemClicked += OnItemClicked;
        }
    }

    private void OnDisable()
        {
            if (virtualItemList != null)
            {
                virtualItemList.OnItemClicked -= OnItemClicked;
            }
        }

    private void OnItemClicked(ItemData item)
    { 
        Debug.Log($"点击了物品：{item.itemName}");
        ItemDetailPanel detailPanel =UIManager.Instance.OpenPanel<ItemDetailPanel>();
        detailPanel.SetData(item);
       
    }
    //通过品质进行筛选
    private List<ItemData> FilterByQuality(ItemQuality quality)
    {
        List<ItemData> filterList = new List<ItemData>();
        if (quality == ItemQuality.All)
        {
            filterList = new List<ItemData>(mockData.Data.items);
        }
        else
        {
            foreach (ItemData item in mockData.Data.items)
            {
                if (item.quality == quality)
                {
                    filterList.Add(item);
                }
            }
        }

        return filterList;
    }
    public void SortByCountDescending()
    {
        sortByCountDescending = true;
        RefreshList();
    }

    public void Show(ItemQuality itemQuality)
    {
        currentQuality = itemQuality;
        RefreshList();
    }

    public void ShowAll()
    {
        Debug.Log("All 按钮被点击");
        Show(ItemQuality.All);
    }

    public void ShowCommon()
    {
        Show(ItemQuality.Common);
    }

    public void ShowUncommon()
    {
        Show(ItemQuality.Uncommon);
    }

    public void ShowRare()
    {
        Show(ItemQuality.Rare);
    }

    public void ShowEpic()
    {
        Show(ItemQuality.Epic);
    }
    public void RefreshList()
    {
        currentList=  FilterByQuality(currentQuality);
        if (sortByCountDescending)
        {
          
            
            currentList.Sort((a, b) =>
            {
            if (a.count > b.count)
               {
                return -1;
                }
            else if (a.count < b.count)
                {
                return 1;
                }
            else
                {
                return 0;
               }
            });
        }
        virtualItemList.SetData(currentList);

    }
}