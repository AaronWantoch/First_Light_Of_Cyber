using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gameStartCanvas;

    private void Start()
    {
        FindObjectOfType<Weapon>().enabled = false;
        FindObjectOfType<WeaponZoom>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ActivateDeathScreen()
    {
        gameOverCanvas.SetActive(true);
    }

    public void StartMission()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        gameStartCanvas.SetActive(false);

        FindObjectOfType<Weapon>().enabled = true;
        FindObjectOfType<WeaponZoom>().enabled = true;
    }
}
