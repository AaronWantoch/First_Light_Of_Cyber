using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float timeDisplaying = 5f;

    [SerializeField] GameObject damageCanvas;

    public void Display()
    {
        StartCoroutine(HandleCanvasDisplay());
    }

    IEnumerator HandleCanvasDisplay()
    {
        damageCanvas.SetActive(true);
        yield return new WaitForSeconds(timeDisplaying);
        damageCanvas.SetActive(false);
    }
}
