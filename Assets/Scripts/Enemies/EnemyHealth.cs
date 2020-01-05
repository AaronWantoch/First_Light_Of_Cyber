using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    bool dead = false;

    public void DecreaseHealth(float damage)
    {
        BroadcastMessage("Provoke");

        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    private void Die()
    {
        Animator animator = GetComponent<Animator>();
        EnemyAI enemyAI = GetComponent<EnemyAI>();
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.enabled = false;
        enemyAI.enabled = false;
        dead = true;

        animator.SetTrigger("Dead");
    }
}
