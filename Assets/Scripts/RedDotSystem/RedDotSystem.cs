using System.Collections.Generic;
using UnityEngine;

public class RedDotSystem : MonoBehaviour
{
    [Header("Red Dot")]
    [SerializeField] private RedDotUI redDotPrefab;

    [Header("UI Target")]
    //[SerializeField] private Transform mainTarget;
    [SerializeField] private Transform inventoryTarget;
    [SerializeField] private Transform itemTarget;
   // [SerializeField] private Transform equipmentTarget;

    //private RedDotNode mainNode;
    private RedDotNode inventoryNode;
    private RedDotNode itemNode;
  //  private RedDotNode equipmentNode;

    private Dictionary<RedDotNode, Transform> nodeTargets
        = new Dictionary<RedDotNode, Transform>();

    private Dictionary<RedDotNode, RedDotUI> redDotViews
        = new Dictionary<RedDotNode, RedDotUI>();

    private void Awake()
    {
        CreateNodes();
        BindTargets();
        BindNodeEvents();
    }

    private void OnEnable()
    {
        EventBus.Subscribe<ItemObtainedEvent>(OnItemObtained);
        EventBus.Subscribe<ItemViewedEvent>(OnItemViewed);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe<ItemObtainedEvent>(OnItemObtained);
    }
    private void OnItemViewed(ItemViewedEvent eventData)
    {
        itemNode.SetRedDot(false);
    }

    private void CreateNodes()
    {
       // mainNode = new RedDotNode();
        inventoryNode = new RedDotNode();
        itemNode = new RedDotNode();
       // equipmentNode = new RedDotNode();

        // 建立树结构
      //  inventoryNode.Parent = mainNode;

        itemNode.Parent = inventoryNode;
        //equipmentNode.Parent = inventoryNode;

        inventoryNode.Children.Add(itemNode);
        //inventoryNode.Children.Add(equipmentNode);
    }

    private void BindTargets()
    {
       // nodeTargets.Add(mainNode, mainTarget);
        nodeTargets.Add(inventoryNode, inventoryTarget);
        nodeTargets.Add(itemNode, itemTarget);
       // nodeTargets.Add(equipmentNode, equipmentTarget);
    }

    private void BindNodeEvents()
    {
       // mainNode.OnStateChanged += OnNodeStateChanged;
        inventoryNode.OnStateChanged += OnNodeStateChanged;
        itemNode.OnStateChanged += OnNodeStateChanged;
        // equipmentNode.OnStateChanged += OnNodeStateChanged;
    }

    private void OnNodeStateChanged(RedDotNode node, bool hasRedDot)
    {
        //if (!hasRedDot)
        //    return;

        //if (!nodeTargets.TryGetValue(node, out Transform target))
        //    return;

        //RedDotUI redDot = Instantiate(redDotPrefab);

        //redDot.transform.SetParent(target, false);

        //redDot.Show();
    }
    private void OnItemObtained(ItemObtainedEvent eventData)
    {
        // 获得新物品
        // → Item 叶子节点亮
        itemNode.SetRedDot(true);
    }
}