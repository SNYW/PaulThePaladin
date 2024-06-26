using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestManager : MonoBehaviour
{
    private NavMeshAgent _paulNavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        _paulNavMeshAgent = GameObject.Find("Paul").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit)) {
                _paulNavMeshAgent.destination = hit.point;
            }
        }
    }
}
