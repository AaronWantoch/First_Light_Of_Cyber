using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPickup : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
        GetComponent<AudioSource>().Play();

        FindObjectOfType<Weapon>().enabled = false;
        FindObjectOfType<WeaponZoom>().enabled = false;
    }
}
