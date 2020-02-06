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
        //particle = GetComponentInChildren<ParticleSystem>();
        target = FindObjectOfType<PlayerHealth>();
    }

    void DealDamage()
    {
        target.DecreaseHealth(damage);
        target.GetComponent<DisplayDamage>().Display();

        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();
        
    }
}
