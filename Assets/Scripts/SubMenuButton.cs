using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    public MenuData linkedMenu;

    public void OnClickMenuButton()
    {
        SystemEventManager.RaiseEvent(SystemEventManager.SystemEventType.MenuUpdate, linkedMenu);
    }
}
