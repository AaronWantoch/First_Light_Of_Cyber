using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DecreaseHealth(float damage)
    {
        BroadcastMessage("Provoke");
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
