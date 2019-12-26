using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeponZoom : MonoBehaviour
{
    [SerializeField] float defaultZoom = 60f;
    [SerializeField] float zoom = 30f;

    [SerializeField] float defaultSensitivity = 2f;
    [SerializeField] float sensitivity = 1f;

    Camera camera;
    RigidbodyFirstPersonController player;

    private void Start()
    {
        camera = GetComponentInChildren<Camera>();
        player = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetMouseButton(1))
        {
            camera.fieldOfView = zoom;
            player.mouseLook.XSensitivity = sensitivity;
            player.mouseLook.YSensitivity = sensitivity;
        }
        else
        {
            camera.fieldOfView = defaultZoom;
            player.mouseLook.XSensitivity = defaultSensitivity;
            player.mouseLook.YSensitivity = defaultSensitivity;
        }
    }
}
