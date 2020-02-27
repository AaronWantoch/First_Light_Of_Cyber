using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    [SerializeField] Slider healthBar;

    float maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;

        healthBar.value = health / maxHealth;

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
        if(FindObjectOfType<WeaponZoom>())
            FindObjectOfType<WeaponZoom>().enabled = false;
    }
}
