using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 30f;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<RigidbodyFirstPersonController>().transform;
    }

    void DealDamage()
    {
        Debug.Log("bang");
    }
}
