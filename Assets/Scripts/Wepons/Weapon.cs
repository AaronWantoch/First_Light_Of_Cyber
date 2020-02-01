using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform FPCamera;
    [SerializeField] ParticleSystem muzzleFlashFX;
    [SerializeField] GameObject hitFX;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float range = 100f;
    [SerializeField] float damage = 5f;
    [SerializeField] float shootDelay = 0.5f;

    Ammo ammo;

    bool canShoot = true;

    private void OnEnable()
    {
        ammo = GetComponentInParent<Ammo>();
        ammo.UpdateUI(ammoType);
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.GetAmmoAmount(ammoType) > 0)
        {
            UseMuzzleFlash();
            PlayShootSound();
            ProcessRaycast();
            ammo.DecreaseAmmoAmount(ammoType);
            ammo.UpdateUI(ammoType);
        }
        else
        {
            Debug.Log("out of ammo");
        }

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
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

    private void PlayShootSound()
    {
        GetComponent<AudioSource>().Play();
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

    void UseMuzzleFlash()
    {
        muzzleFlashFX.Play();
    }

    private void OnDisable()
    {
        canShoot = true;
    }

    public AmmoType GetCurrentAmmoType()
    {
        return ammoType;
    }
}
