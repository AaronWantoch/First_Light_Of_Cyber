using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(!Physics.Raycast(FPCamera.position, FPCamera.forward, out hit, range))
        {
            return;
        }

        EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
        if(!enemyHealth)
        {
            return;
        }
        enemyHealth.DecreaseHealth(damage);
    }
}
