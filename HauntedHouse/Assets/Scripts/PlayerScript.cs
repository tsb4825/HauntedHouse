using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float PlayerSpeed;
    public float LookSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        MoveCamera();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * PlayerSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + transform.forward * -1 * Time.deltaTime * PlayerSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + transform.right * -1 * Time.deltaTime * PlayerSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Time.deltaTime * PlayerSpeed;
        }
    }

    private void MoveCamera()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(transform.up * rotateHorizontal * LookSensitivity);

        float rotateVertical = Input.GetAxis("Mouse Y");
        var playerCamera = GameObject.Find("Main Camera");
        Vector3 localX = transform.TransformDirection(Vector3.right);

        playerCamera.transform.RotateAround(playerCamera.transform.position, localX, rotateVertical * LookSensitivity);
    }
}
