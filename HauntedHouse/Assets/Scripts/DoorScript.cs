using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorScript : Interactable
{
    public float DoorMovementSpeed;

    private bool _isClosed = true;
    private bool _isMoving;
    private bool PlayedClosedSound = false;
    private AudioSource DoorOpen;
    private AudioSource DoorClose;

    private const float EulerAngleOpen = 250;

    // Start is called before the first
    // frame update
    void Start()
    {
        var audioClips = this.GetComponents<AudioSource>();
        DoorOpen = audioClips.First();
        DoorClose = audioClips.Skip(1).First();
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
                if (newEulerY >= 320 && !this.PlayedClosedSound)
                {
                    this.PlayedClosedSound = true;
                    this.DoorClose.Play();
                }

                if (newEulerY >= 360)
                {
                    hingeJoint.rotation = Quaternion.Euler(0, 0, 0);
                    _isMoving = false;
                    this.PlayedClosedSound = false;
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
            if (this._isClosed)
            {
                this.DoorOpen.Play();
            }

            _isClosed = !_isClosed;
            _isMoving = true;
        }
    }
}
