using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform FPCamera;
    [SerializeField] ParticleSystem muzzleFlashFX;
    [SerializeField] GameObject hitFX;

    [SerializeField] float range = 100f;
    [SerializeField] float damage = 5f;

    Ammo ammo;

    private void Start()
    {
        ammo = GetComponent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else
        {
            ControllGuns(false);
        }
    }

    private void Shoot()
    {
        if (ammo.GetAmmoAmount() > 0)
        {
            ControllGuns(true);
            ProcessRaycast();
            ammo.DecreaseAmmoAmount();
        }
        else
            Debug.Log("out of ammo");
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (!Physics.Raycast(FPCamera.position, FPCamera.forward, out hit, range))
        {
            return;
        }

        GenerateHitParticles(hit);

        EnemyHealth enemyHealth = hit.transform.GetComponentInParent<EnemyHealth>();
        EnemyAI enemyAI = hit.transform.GetComponentInParent<EnemyAI>();
        if (!enemyHealth || !enemyAI)
        {
            return;
        }

        enemyHealth.DecreaseHealth(damage);
    }

    private void GenerateHitParticles(RaycastHit hit)
    {
        GameObject hitObject 
            = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));

        ParticleSystem[] particleSystems = hitFX.GetComponentsInChildren<ParticleSystem>();
        float duration = Maximum(particleSystems);

        Destroy(hitObject, duration);
    }

    private float Maximum(ParticleSystem[] particleSystems)
    {
        float maximumDuration = 0f;

        foreach(ParticleSystem particle in particleSystems)
        {
            float duration = particle.duration;
            if (duration > maximumDuration)
            {
                maximumDuration = duration;
            }
        }

        return maximumDuration;
    }

    void ControllGuns(bool activate)
    {
        ParticleSystem.EmissionModule emiter = muzzleFlashFX.emission;

        emiter.enabled = activate;
    }
}
