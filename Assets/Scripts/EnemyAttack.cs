using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 30f;

    PlayerHealth target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    void DealDamage()
    {
        Debug.Log("bang");
        target.DecreaseHealth(damage);
    }

   
}
