using System;
using Unity.Collections;
using UnityEngine;

public class PaulManager : MonoBehaviour
{
    [SerializeField][ReadOnly]private Actions currentAction;
    
    enum Actions
    {
        MoveToTarget,
        AttackTarget,
        CollectQuest,
        UpgradeGear
    }

    private void OnEnable()
    {
        SystemEventManager.Subscribe(SystemEventManager.SystemEventType.QuestCreated, OnQuestCreated);
    }

    private void OnQuestCreated(object obj)
    {
       
    }

    private void OnDisable()
    {
        
    }
}
