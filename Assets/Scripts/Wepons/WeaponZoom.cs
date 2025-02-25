﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float defaultZoom = 60f;
    [SerializeField] float zoom = 30f;

    [SerializeField] float defaultSensitivity = 2f;
    [SerializeField] float sensitivity = 1f;

    Camera camera;
    RigidbodyFirstPersonController player;

    private void OnEnable()
    {
        camera = GetComponentInParent<Camera>();
        player = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetMouseButton(1))
        {
            ChangeZoomState(zoom, sensitivity);
        }
        else
        {
            ChangeZoomState(defaultZoom, defaultSensitivity);
        }
    }

    private void ChangeZoomState(float newZoom, float newSensitivity)
    {
        camera.fieldOfView = newZoom;
        player.mouseLook.XSensitivity = newSensitivity;
        player.mouseLook.YSensitivity = newSensitivity;
    }

    private void OnDisable()
    {
        ChangeZoomState(defaultZoom, defaultSensitivity);
    }
}
