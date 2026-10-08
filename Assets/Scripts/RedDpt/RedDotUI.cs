using UnityEngine;

public class RedDotUI : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void OnStateChanged(bool hasRedDot)
    {
        if (hasRedDot)
            Show();
        else
            Hide();
    }


}
