using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject currentObject;
    private bool buildModeActive;
    public LayerMask buildTargetLayer;
    public BuildData debugData;
    
    private void Start()
    {
        buildModeActive = false;
        SystemEventManager.Subscribe(SystemEventManager.SystemEventType.BuildModeEntered, OnEnterBuildMode);
    }

    public void OnDisable()
    {
        SystemEventManager.Unsubscribe(SystemEventManager.SystemEventType.BuildModeEntered, OnEnterBuildMode);
    }

    private void OnEnterBuildMode(object obj)
    {
        if (obj is not BuildData data || buildModeActive) return;
        
        buildModeActive = true;
        currentObject = Instantiate(data.prefab);
    }

    private bool GetBuildPosition(out Vector3 pos)
    {
        pos = Vector3.zero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit, Int32.MaxValue,buildTargetLayer)) return false;
        
        pos = hit.point;
        return true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnEnterBuildMode(debugData);
        }
        if (!buildModeActive || currentObject == null) return;

        currentObject.gameObject.SetActive(GetBuildPosition(out var pos));
        currentObject.transform.position = pos;

        if (Input.GetKey(KeyCode.Escape))
        {
            Destroy(currentObject);
            buildModeActive = false;
        }
    }
}
