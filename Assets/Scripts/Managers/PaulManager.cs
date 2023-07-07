using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PaulManager : MonoBehaviour
{
    [SerializeField]private Actions currentAction;
    [SerializeField]private GameObject idleAnchor;
    private Paul _paul;
    
    private NavMeshAgent _paulNavMeshAgent;
    private Transform[] idlePositions;
    
    enum Actions
    {
        Idle,
        MoveToTarget,
        AttackTarget,
        CollectQuest,
        UpgradeGear
    }

    private void OnEnable()
    {
        _paul = GameObject.Find("Paul").GetComponent<Paul>();
        _paulNavMeshAgent = GameObject.Find("Paul").GetComponent<NavMeshAgent>();

        StartCoroutine(ManageIdleWander());

        idlePositions = idleAnchor.GetComponentsInChildren<Transform>();
        currentAction = Actions.Idle;
        SystemEventManager.Subscribe(SystemEventManager.SystemEventType.QuestCreated, OnQuestCreated);
    }

    private void OnQuestCreated(object obj)
    {
       
    }

    public IEnumerator ManageIdleWander()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            yield return new WaitUntil(() => !_paulNavMeshAgent.hasPath);
            yield return new WaitForSeconds(5);
            
            if (currentAction == Actions.Idle)
            {
                _paulNavMeshAgent.SetDestination(idlePositions[Random.Range(0, idlePositions.Length)].position);
            }
        }
    }
}
