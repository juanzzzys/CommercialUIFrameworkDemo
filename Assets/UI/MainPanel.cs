using UnityEngine;

public class MainPanel : BasePanel
{

    public void Onclick()
    {
        UIManager.Instance.OpenPanel<InventoryPanel>();
        
    }
}
