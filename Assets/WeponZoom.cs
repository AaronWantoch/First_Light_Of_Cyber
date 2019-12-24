using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponZoom : MonoBehaviour
{
    [SerializeField] float defaultZoom = 60f;
    [SerializeField] float zoom = 30f;

    Camera camera;

    private void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetMouseButton(1))
        {
            camera.fieldOfView = zoom;
        }
        else
        {
            camera.fieldOfView = defaultZoom;
        }
    }
}
