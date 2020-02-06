using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DecreaseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            HandleDeath();
        }
    }

    private static void HandleDeath()
    {
        FindObjectOfType<GameManager>().ActivateDeathScreen();

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FindObjectOfType<Weapon>().enabled = false;
        FindObjectOfType<WeaponZoom>().enabled = false;
    }
}
