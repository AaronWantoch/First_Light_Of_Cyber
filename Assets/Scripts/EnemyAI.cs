using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float chaseRange;

    NavMeshAgent navMeshAgent;
    float distanceToPlayer = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if(isProvoked)
        {
            Engage();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            isProvoked = true;

            Chase();
        }
    }

    private void Engage()
    {
        if (distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            Fight();
        }
        else
        {
            Chase();
        }
    }

    private void Fight()
    {
        print("Fighting");
    }

    private void Chase()
    {
        navMeshAgent.SetDestination(player.position);
    }

    void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
