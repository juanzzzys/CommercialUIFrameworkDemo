using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class BasePanel : MonoBehaviour
{
    [SerializeField] private UILayer layer = UILayer.Normal;
    [SerializeField] private bool useStack = true;

    public UILayer Layer => layer;
    public bool UseStack => useStack;

    protected CanvasGroup canvasGroup;

    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Hide();
         UIManager.Instance.RegisterPanel(this);
    }

    public virtual void OnEnter()
    {
        Show();
    }

    public virtual void OnPause()
    {
        Hide();
    }

    public virtual void OnResume()
    {
        Show();
    }

    public virtual void OnExit()
    {
        Hide();
    }

    public void Show()
    {
        
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
