using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VirtualItemList : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform content;
    [SerializeField] private ItemCellPool pool;
    [SerializeField] private float cellHeight = 200f;
    [SerializeField] private float spacing = 10f;
    [SerializeField] private int bufferCount = 2;
    [SerializeField] private float cellWidth = 200f;
    [SerializeField] private int columnCount = 4;

    private RectTransform viewport;
    private List<ItemData> dataList = new List<ItemData>();
    private List<ItemCell> cells = new List<ItemCell>();
    private int currentStartIndex = -1;
    //VirtualItemList 对外通知：列表中有一个物品被点击了，并传出对应的 ItemData。
    public event Action<ItemData> OnItemClicked;

    private void Awake()
    {
        viewport = scrollRect.viewport;
    }

    private void Start()
    {
        CreateCells();
        UpdateContentHeight();
        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
        Refresh();
    }
    

    public void SetData(List<ItemData> data)
    {
        dataList = data;

        currentStartIndex = -1;
        scrollRect.verticalNormalizedPosition = 1f;

        UpdateContentHeight();

        Canvas.ForceUpdateCanvases();


        Refresh();
        Canvas.ForceUpdateCanvases();
        Refresh();
    }
    private void OnCellClicked(ItemData item)
    {
        OnItemClicked?.Invoke(item);
    }


    private void CreateCells()
    {
        Canvas.ForceUpdateCanvases();
       Refresh();
        float itemSize = cellHeight + spacing;
       // Debug.Log($"Viewport Height: {viewport.rect.height}, Cell Height: {cellHeight}, Spacing: {spacing}");
       int visibleRowCount = Mathf.CeilToInt(viewport.rect.height / itemSize);

        if (visibleRowCount < 1)
        {
            visibleRowCount = 1;
        }

        int cellCount = (visibleRowCount + bufferCount) * columnCount;
        for (int i = 0; i < cellCount; i++)
        {
            ItemCell cell = pool.Get();
            cell.transform.SetParent(content, false);
            cells.Add(cell);
            cell.Onclicked += OnCellClicked;
        }
        
    }

     private void UpdateContentHeight()
    {
        int count = dataList != null ? dataList.Count : 0;

        if (count == 0)
        {
            content.sizeDelta = new Vector2(content.sizeDelta.x, 0f);
            return;
        }

        int rowCount = Mathf.CeilToInt((float)count / columnCount);

        float rowSize = cellHeight + spacing;

        float height = rowCount * cellHeight + (rowCount - 1) * spacing;

        content.sizeDelta = new Vector2(content.sizeDelta.x, height);
    }

    private void OnScrollValueChanged(Vector2 value)
    {
        Refresh();
    }

    private void Refresh()
    {
        Debug.Log($"Refresh开始: cells.Count={cells.Count}, currentStartIndex={currentStartIndex}");

        if (cells.Count == 0)
        {
           Debug.Log("Refresh提前退出：cells.Count == 0");
            return;
        }

        float itemSize = cellHeight + spacing;
        int startRow = Mathf.Max(0, Mathf.FloorToInt(content.anchoredPosition.y / itemSize));
        int startIndex = startRow * columnCount;
//        Debug.Log(
//     $"startIndex={startIndex}, " +
//     $"currentStartIndex={currentStartIndex}, " +
//     $"contentY={content.anchoredPosition.y}, " +
//     $"itemSize={itemSize}"
// );
        if (startIndex == currentStartIndex)
        {
             Debug.Log("Refresh提前退出：startIndex没有变化");
             return;
            }   
        currentStartIndex = startIndex;
        for (int i = 0; i < cells.Count; i++)
        {
            int dataIndex = startIndex + i;
            int column = dataIndex % columnCount;
            int row = dataIndex / columnCount;
            ItemCell cell = cells[i];

            if (dataList == null || dataIndex < 0 || dataIndex >= dataList.Count)
            {
                cell.gameObject.SetActive(false);
                continue;
            }

            cell.gameObject.SetActive(true);
           // Debug.Log($"准备设置Cell：i={i}, dataIndex={dataIndex}");
            cell.SetData(dataList[dataIndex]);

            RectTransform cellRect = cell.transform as RectTransform;


            float x = column * (cellWidth + spacing);
            float y = -row * (cellHeight + spacing);

            cellRect.anchoredPosition = new Vector2(x, y);
//             Debug.Log(
//     $"Cell {i}: dataIndex={dataIndex}, " +
//     $"anchoredY={cellRect.anchoredPosition.y}"
// );
        }
    }
   
}

