using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveHandTracking;

class GrabBehaviour : MonoBehaviour
{
    private static Color enterColor = new Color(0, 0, 0.3f, 1);
    private static Color moveColor = new Color(0, 0.3f, 0, 1);

    private Rigidbody _target = null;
    private Transform _anchor = null;
    private int _state = 0;
    private bool _exit = true;

    void Awake()
    {
        var go = new GameObject("Anchor");
        _anchor = go.transform;
        _anchor.parent = transform;
    }

    void Update()
    {
        if (_state == 1 && _target != null)
        {
            _anchor.position = transform.position;
            if (GestureProvider.HaveSkeleton)
                _anchor.rotation = transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.StartsWith("Cube"))
            return;

        var newTarget = other.GetComponent<Rigidbody>();
        if (newTarget == _target)
        {
            _exit = false;
            return;
        }
        if (_target != null && _state == 1)
            StopMove();
        _target = other.GetComponent<Rigidbody>();
        if (_target != null)
        {
            _exit = false;
            if (_state == 1)
                StartMove();
            else
                SetColor(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != _target)
            return;
        if (_state == 1)
            _exit = true;
        else
        {
            SetColor(null);
            _target = null;
        }
    }

    public void OnStateChanged(int state)
    {
        this._state = state;
        if (_target == null)
            return;
        if (state == 1)
            StartMove();
        else if (state == 0)
        {
            StopMove();
            if (_exit)
                _target = null;
            else
                SetColor(false);
        }
    }

    void StartMove()
    {
        _target.useGravity = false;
        _target.isKinematic = true;
        _target.GetComponent<Grabbable>().OnGrab(_anchor);
        //_anchor.SetParent(_target.transform.parent, true);
        //_target.transform.SetParent(_anchor, true);
        SetColor(true);
    }

    void StopMove()
    {
        //_target.transform.SetParent(_anchor.parent, true);
        //_anchor.parent = transform;
        _target.GetComponent<Grabbable>().OnRelease();
        _target.useGravity = true;
        _target.isKinematic = false;
        SetColor(null);
    }

    // true: moving, false: touching, null: not touched
    void SetColor(bool? moving)
    {
        if (_target == null)
            return;
        var renderer = _target.GetComponent<Renderer>();
        if (renderer == null)
            return;
        var material = renderer.material;
        if (moving == null)
        {
            material.DisableKeyword("_EMISSION");
            return;
        }
        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", moving.Value ? moveColor : enterColor);
    }
}

