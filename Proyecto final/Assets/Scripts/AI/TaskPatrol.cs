using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;
using Unity.VisualScripting;

public class TaskPatrol : BehaviorTree.Node
{
    EnemyBT enemyBT;
    NavMeshAgent agent;
    private int cont;
    Transform target;
    private bool isWaiting;

    public TaskPatrol(BTree bTree) : base(bTree)
    {
        enemyBT = bTree as EnemyBT;
        agent = enemyBT.transform.GetComponent<NavMeshAgent>();
        cont = 0;
        isWaiting = false;
    }

    public override NodeState Evaluate()
    {
        target = enemyBT.points[cont];
        if (target != null) agent.destination = target.position;

        if (Vector2.Distance(new Vector2(enemyBT.transform.position.x, enemyBT.transform.position.z), new Vector2(agent.destination.x, agent.destination.z)) <= 0.8f)
            if (!isWaiting) bTree.StartCoroutine(CorWaitEnemy());

        state = NodeState.RUNNING;
        return state;
    }

    IEnumerator CorWaitEnemy()
    {
        isWaiting = true;
        enemyBT.velocidad = 0;
        agent.speed = 0;
        enemyBT.ReloadAnimation();
        yield return new WaitForSeconds(enemyBT.timeToWait);
        cont++;
        if (cont == enemyBT.points.Count) cont = 0;
        isWaiting = false;
        enemyBT.velocidad = 0.4f;
        agent.speed = 4.5f;
        enemyBT.ReloadAnimation();
    }
}
