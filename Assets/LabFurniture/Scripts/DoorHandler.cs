using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField]private HingeJoint _doorJoint;

    [SerializeField]private HingeJoint _handleJoint;
    private float _triggerAngle = -18f;
    private bool _doorIsLocked = true;
    private float _closeAngle = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _doorJoint.GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_doorIsLocked)
        {
            if (_handleJoint.angle <= _triggerAngle)
            {
                _doorIsLocked = false;
                _doorJoint.GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
        else
        {
            if (_doorJoint.angle <= _closeAngle && _handleJoint.angle > _triggerAngle)
            {
                _doorIsLocked = true;
                _doorJoint.GetComponent<Rigidbody>().freezeRotation = true;
            }
        }
    }
}
