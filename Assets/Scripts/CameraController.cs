using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Third Person")]
    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] CinemachineFreeLook freeLookCamera;
    [SerializeField] float thirdPersonMouseSensitivity = 1f;
    [Header("First Person")]
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] float fpsMouseSensitivity = 2f;


    CinemachineComposer aim;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if(Input.GetMouseButton(1) == false)
        {
            var vertical = Input.GetAxis("Mouse Y") * thirdPersonMouseSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, 0f, 2.5f);
        }

        var fpsVertical = Input.GetAxis("Mouse Y") * fpsMouseSensitivity;
        fpsCamera.transform.Rotate(Vector3.right, -fpsVertical);

    }
}
