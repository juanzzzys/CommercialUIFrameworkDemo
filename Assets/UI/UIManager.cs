using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform backgroundLayer;
    [SerializeField] private Transform normalLayer;
    [SerializeField] private Transform popupLayer;
    [SerializeField] private Transform topLayer;

    private Dictionary<Type, BasePanel> panelDict = new Dictionary<Type, BasePanel>();
    private Stack<BasePanel> panelStack = new Stack<BasePanel>();
    private Dictionary<UILayer, Transform> layerDict;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance!=null&&Instance!=this){
            Destroy(this.gameObject);
            return;
        }
        Instance=this;
        layerDict = new Dictionary<UILayer, Transform>
        {
            { UILayer.Background, backgroundLayer },
            { UILayer.Normal, normalLayer },
            { UILayer.Popup, popupLayer },
            { UILayer.Top, topLayer }
        };
    }
    private void Start()
    {
        OpenPanel<MainPanel>();
    }
    public void RegisterPanel(BasePanel panel)
    {
        Type type = panel.GetType();
        panelDict[type] = panel;
       
    }

    public T GetPanel<T>() where T : BasePanel
    {
        Type type = typeof(T);
        if (panelDict.TryGetValue(type, out BasePanel panel))
        {
            return panel as T;
        }

        Debug.LogError($"Panel {type.Name} is not registered.");
        return null;
    }

    public T OpenPanel<T>() where T : BasePanel
    {
        T panel = GetPanel<T>();
        if (panel == null)
        {
            return null;
        }

        Transform targetTransform = GetLayerTransform(panel.Layer);
        if (targetTransform == null)
        {
            return null;
        }

        if (panel.UseStack)
        {
            if (panelStack.Count > 0)
            {
                BasePanel topPanel = panelStack.Peek();
                if (topPanel == panel)
                {
                    return panel;
                }

                topPanel.OnPause();
            }

            panelStack.Push(panel);
        }

        panel.transform.SetParent(targetTransform, false);
        panel.OnEnter();
        return panel;
    }

    public void Back()
    {
        if (panelStack.Count == 0)
        {
            return;
        }

        BasePanel currentPanel = panelStack.Pop();
        currentPanel.OnExit();

        if (panelStack.Count > 0)
        {
            BasePanel previousPanel = panelStack.Peek();
            previousPanel.OnResume();
        }
    }

    public void ClosePanel<T>() where T : BasePanel
    {
        T panel = GetPanel<T>();
        if (panel == null)
        {
            return;
        }

        panel.OnExit();
    }

    private Transform GetLayerTransform(UILayer layer)
    {
        if (layerDict.TryGetValue(layer, out Transform targetTransform) && targetTransform != null)
        {
            return targetTransform;
        }

        Debug.LogError($"Layer transform for {layer} is not assigned.");
        return null;
    }
}
