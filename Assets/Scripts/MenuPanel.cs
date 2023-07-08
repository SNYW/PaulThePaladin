using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public MenuData defaultMenu;
    private void Start()
    {
        OnUpdateMenu(defaultMenu);
        SystemEventManager.Subscribe(SystemEventManager.SystemEventType.MenuUpdate, OnUpdateMenu);
    }
    
    private void OnDisable()
    {
        SystemEventManager.Unsubscribe(SystemEventManager.SystemEventType.MenuUpdate, OnUpdateMenu);
    }
    
    private void OnUpdateMenu(object obj)
    {
        if (obj is not MenuData data) return;
        if(transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
        Instantiate(data.menuPrefab, transform);
    }
}
