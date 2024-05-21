using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class TaskGoToTarget : Node
{
    EnemyBT enemyBT;
    UnityEngine.AI.NavMeshAgent agent;

    public TaskGoToTarget(BTree btree) : base(btree)
    {
        enemyBT = bTree as EnemyBT;
        agent = enemyBT.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        //Debug.Log(ghostBT.chompLayerMask);
        Transform target = (Transform)bTree.GetData("target");
        if (target != null)
        {
            agent.destination = target.position;
            
        }else
        {
            enemyBT.velocidad = 0.4f;
            enemyBT.ReloadAnimation();
        }
        state = NodeState.RUNNING;
        return state;
    }

}
