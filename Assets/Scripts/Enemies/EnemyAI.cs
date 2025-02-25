﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float chaseRange;
    [SerializeField] float turnSpeed = 50f;

    NavMeshAgent navMeshAgent;
    Animator animator;
    Transform player;

    float distanceToPlayer = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerHealth>().transform;
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
        FaceTarget();
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
        animator.SetBool("Attack", true);
    }

    private void Chase()
    {
        animator.SetTrigger("Move");
        animator.SetBool("Attack", false);
        navMeshAgent.SetDestination(player.position);
    }

    void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation =
            Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation =
            Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void Provoke()
    {
        isProvoked = true;
    }
}
