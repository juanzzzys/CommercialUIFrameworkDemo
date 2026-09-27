using System.Collections;
using UnityEngine;

public class UIManagerTest : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private MainPanel mainPanel;
    [SerializeField] private ItemDetailPanel itemDetailPanel;
   [SerializeField] private InventoryPanel inventoryPanel;
[SerializeField] private LoadingPanel loadingPanel;
    

  private void Start()
{
    uiManager.RegisterPanel(mainPanel);
    uiManager.RegisterPanel(inventoryPanel);
    uiManager.RegisterPanel(itemDetailPanel);
    uiManager.RegisterPanel(loadingPanel);

    // uiManager.OpenPanel<MainPanel>();
    uiManager.OpenPanel<InventoryPanel>();
    // uiManager.OpenPanel<ItemDetailPanel>();
    // uiManager.OpenPanel<LoadingPanel>();
}
// private void Update()
// {
//     if (Input.GetKeyDown(KeyCode.B))
//     {
//         uiManager.Back();
//     }
//     if (Input.GetKeyDown(KeyCode.L))
// {
//     uiManager.ClosePanel<LoadingPanel>();
// }
// }
    // private IEnumerator CloseAfterDelay()
    // {
    //     yield return new WaitForSeconds(2f);
    //     uiManager.ClosePanel<MainPanel>();
    // }
}
