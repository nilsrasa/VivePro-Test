using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Transform _target;

    private bool _isGrabbed = false;

    [SerializeField]private float _moveSpeed = 6f;

    [SerializeField] private float _turnSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _target = new GameObject("AnchorPoint").transform;
        _target.SetParent(transform);
        _target.localPosition = Vector3.zero;
        _target.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrabbed)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, Time.deltaTime * _turnSpeed);
        }
    }

    public void OnGrab(Transform anchor)
    {
        _target.SetParent(anchor, true);
        _isGrabbed = true;
    }

    public void OnRelease()
    {
        _isGrabbed = false;
        _target.SetParent(transform);
        _target.localPosition = Vector3.zero;
        _target.localRotation = Quaternion.identity;
    }
}
