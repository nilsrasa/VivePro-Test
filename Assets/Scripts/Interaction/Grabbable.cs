using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    private const float MoveSpeed = 6f;
    private const float TurnSpeed = 4f;

    private Transform _target;

    private bool _isGrabbed = false;

    public bool IsGrabbed => _isGrabbed;

    private Rigidbody _rigidbody;

    void Awake()
    {
        _target = new GameObject("AnchorPoint").transform;
        _target.SetParent(transform);
        _target.localPosition = Vector3.zero;
        _target.localRotation = Quaternion.identity;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrabbed)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * MoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, Time.deltaTime * TurnSpeed);
        }
    }

    void FixedUpdate()
    {
        if (_isGrabbed)
        {
            //_rigidbody.AddForce((_target.position - transform.position) * 10f);
        }
    }

    public void OnGrab(Transform anchor)
    {
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _target.SetParent(anchor, true);
        _isGrabbed = true;
    }

    public void OnRelease()
    {
        _isGrabbed = false;
        _target.SetParent(transform);
        _target.localPosition = Vector3.zero;
        _target.localRotation = Quaternion.identity;
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
    }
}
