using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class EnemyBT : BTree
{
    public List<Transform> points;
    public LayerMask layerMask;
    public float radius;
    public float timeToWait = 2f;
    public Animator animator;
    public float velocidad = 0.0f;
    public float aceleracion = 0.1f;
    public float desaceleracion = 0.5f;


    protected override Node SetupTree()
    {
        Node root = new Selector(this, new List<Node>(){
            new Sequence(this,new List<Node>(){
                new TaskIsOnRange(this),
                new TaskGoToTarget(this)
            }),
            new TaskPatrol(this)
        });
        velocidad = 0.4f;
        ReloadAnimation();
        return root;
    }

    public void ReloadAnimation()
    {
        animator.SetFloat("Velocity", velocidad);
    }
}
