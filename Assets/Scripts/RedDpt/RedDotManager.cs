using System.Collections.Generic;
using UnityEngine;

public class RedDotManager : MonoBehaviour
{
    [SerializeField]
    private MockInventoryData mockData;
    [SerializeField]
    private RedDotUI redDotPrefab;
    [SerializeField]
    private Transform inventoryButton;
    public static RedDotManager Instance { get; private set; }

    //存储已经查看过的item的itemid 
    private HashSet<int> viewedItemIds = new HashSet<int>();
    //这个字典是记录 比如zhegItemCell下创建了红点prefab 将其记录下来
    private Dictionary<Transform,RedDotUI> redDotDic=new Dictionary<Transform,RedDotUI>(); 
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitializeItems(mockData.Data.items);
        RefreshInventoryRedDot();
    }

    public RedDotUI CreateRedDot(Transform target)
    {
        //如果在字典里找到了对应的target  就不继续创建红点了 直接返回字典里的红点
        if(redDotDic.ContainsKey(target)){
            return redDotDic[target];
        }
        RedDotUI redDot=Instantiate(redDotPrefab,target);
        RectTransform rect=redDot.GetComponent<RectTransform>();
        rect.anchorMin=new Vector2(1,1);
        rect.anchorMax=new Vector2(1,1);
        rect.pivot=new Vector2(0.5f,0.5f);
        rect.anchoredPosition=new Vector2(-10,-10);
        //创建好红点和对应基节点（比如设置其中一个ItemCell为基节点）后 将其放进字典
        redDotDic.Add(target,redDot);
        return redDot;
    }
    public void ShowRedDot(Transform target){
        RedDotUI redDot=CreateRedDot(target);
        redDot.Show();
    }
    public void HideRedDot(Transform target){
        //隐藏红点的时候  目标可能根本每创建过红点 如果目标没有创建过红点 就申明也不做 不能报错
        if(redDotDic.TryGetValue(target,out RedDotUI redDot)){
            redDot.Hide();
        }
    }
    public void RefreshInventoryRedDot()
    {
        if (HasNewItem())
        {
            ShowRedDot(inventoryButton);
        }
        else
        {
            HideRedDot(inventoryButton);
        }
    }
  
    public void MarkItemAsViewed(int itemId)
    {
        //hashSet本身就保证元素唯一 所以不用if (!viewedItemIds.Contains(itemId))
        //就算三次Add(101);Add(101);Add(101);结果也是hashset里只有一个101


        viewedItemIds.Add(itemId);
    }
    //查看这个itemid是不是新的
    public bool IsItemNew(int itemId)
    {
        //如果在viewedItemIds这个hashset里 那就不是新的 那就返回false
        return !viewedItemIds.Contains(itemId);
    }
    public void InitializeItems(List<ItemData> items)
    {
        foreach (ItemData item in items)
        {
            viewedItemIds.Add(item.id);
        }
    }
    private void OnItemAdded(ItemData item){
         Debug.Log($"收到新物品：{item.itemName}");
          RefreshInventoryRedDot();
    }
    //谁关心数据变化 就谁dingyueInventory里面的OnItemAdded
    private void OnEnable(){
        mockData.Data.OnItemAdded+=OnItemAdded;
    }
    private void OnDisable(){
        mockData.Data.OnItemAdded-=OnItemAdded;
    }
    // //临时测试
    // [SerializeField]
    // private Transform testTarget;

    // [ContextMenu("Test Show Red Dot")]
    // private void TestShowRedDot()
    // {
    //     ShowRedDot(testTarget);
    // }
    //根据数据里是不是有新数据来判断
    public bool HasNewItem()
    {
        foreach(ItemData item in mockData.Data.items){
            if(IsItemNew(item.id)){
                return true;
            }

        }
        return false;
    }
    public void MarkAllItemsAsViewed()
    {
        foreach (ItemData item in mockData.Data.items)
        {
            MarkItemAsViewed(item.id);
        }

        RefreshInventoryRedDot();
    }

}