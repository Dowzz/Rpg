using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public float PlayerCameraDistance { get; set; }
    public Transform CameraTarget;
    Camera PlayerCamera;
    float ZoomSpeed = 35f;

    void Start()
    {
        PlayerCameraDistance = 12f;
        PlayerCamera = GetComponent<Camera>();
    }
    void Update()
    {
       if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            float Scroll = Input.GetAxis("Mouse ScrollWheel");
            PlayerCamera.fieldOfView -= Scroll * ZoomSpeed;
            PlayerCamera.fieldOfView =  Mathf.Clamp(PlayerCamera.fieldOfView, 1,179);
        }


       transform.position = new Vector3(CameraTarget.position.x, CameraTarget.position.y + PlayerCameraDistance, CameraTarget.position.z - PlayerCameraDistance);
    }




}
