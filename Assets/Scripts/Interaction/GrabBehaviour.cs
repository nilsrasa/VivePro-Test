using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveHandTracking;

class GrabBehaviour : MonoBehaviour
{
    private static Color enterColor = new Color(0, 0, 0.3f, 1);
    private static Color moveColor = new Color(0, 0.3f, 0, 1);

    private Grabbable _target = null;
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

    void OnCollisionEnter(Collision col)
    {
        var newTarget = col.collider.GetComponent<Grabbable>();
        if (newTarget == null || newTarget.IsGrabbed || newTarget == _target)
            return;

        if (_target != null && _state == 1)
            StopMove();

        _target = col.collider.GetComponent<Grabbable>();
        if (_target != null)
        {
            if (_state == 1)
                StartMove();
            else
                SetColor(false);
        }
    }

    /*void OnTriggerExit(Collider other)
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
    }*/

    public void OnStateChanged(int state)
    {
        this._state = state;
        if (_target == null)
            return;
        if (state == 1)
            StartMove();
        else if (state == 2 || state == 0)
        {
            StopMove();
            _target = null;
        }
    }

    void StartMove()
    {
        _target.OnGrab(_anchor);
        SetColor(true);
    }

    void StopMove()
    {
        _target.OnRelease();
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