using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public float DoorMovementSpeed;

    private bool _isClosed = true;
    private bool _isMoving;

    private const float EulerAngleOpen = 250;

    // Start is called before the first
    // frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            var hingeJoint = transform.parent.parent;
            if (_isClosed)
            {
                float newEulerY = hingeJoint.rotation.eulerAngles.y + DoorMovementSpeed * Time.deltaTime;
                hingeJoint.rotation = Quaternion.Euler(0, newEulerY, 0);
                if (newEulerY >= 360)
                {
                    hingeJoint.rotation = Quaternion.Euler(0, 0, 0);
                    _isMoving = false;
                }
            }
            else
            {
                var currentEulerY = hingeJoint.rotation.eulerAngles.y == 0 ? 360 : hingeJoint.rotation.eulerAngles.y;
                float newEulerY = currentEulerY - DoorMovementSpeed * Time.deltaTime;
                hingeJoint.rotation = Quaternion.Euler(0, newEulerY, 0);
                if (newEulerY != 0 && newEulerY <= EulerAngleOpen)
                {
                    hingeJoint.rotation = Quaternion.Euler(0, EulerAngleOpen, 0);
                    _isMoving = false;
                }
            }
        }
    }

    public override void Interact()
    {
        if (!_isMoving)
        {
            _isClosed = !_isClosed;
            _isMoving = true;
        }
    }
}
