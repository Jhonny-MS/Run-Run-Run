using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public Transform pTransform;
    public Transform camTransform;

    Vector2 rotationMouse;
    public int sensibilidade;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 controleMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        rotationMouse = new Vector2(rotationMouse.x + controleMouse.x * sensibilidade * Time.deltaTime, rotationMouse.y + controleMouse.y * sensibilidade * Time.deltaTime);

        pTransform.eulerAngles = new Vector3(pTransform.eulerAngles.x, rotationMouse.x, pTransform.eulerAngles.z);

        rotationMouse.y = Mathf.Clamp(rotationMouse.y, -80, 80);

        camTransform.localEulerAngles = new Vector3(-rotationMouse.y, camTransform.localEulerAngles.y, camTransform.localEulerAngles.z);

    }
}
