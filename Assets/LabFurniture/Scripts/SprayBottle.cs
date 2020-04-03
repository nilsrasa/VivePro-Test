using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using LeapInternal;
using UnityEngine;

[RequireComponent(typeof(InteractionBehaviour))]
[RequireComponent(typeof(DisableOnSuspension))]
public class SprayBottle : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem _ps;

    private DisableOnSuspension _dos;

    private float _sprayInterval = 1f;

    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        InteractionBehaviour _ib;
        _ib = GetComponent<InteractionBehaviour>();
        _ib.OnGraspBegin += OnGraspBegin;
        _ib.OnGraspStay += OnGraspStay;
        _ib.OnGraspEnd += OnGraspEnd;

        _dos = GetComponent<DisableOnSuspension>();
    }

    private void OnGraspBegin()
    {
        //Todo: look into IGraspedPoseHandler, because changing the roation here doesn't affect the object.
    }

    private void OnGraspStay()
    {
        _time -= Time.deltaTime;
        if (!_dos.isSuspended && _time <= 0)
        {
            _time = _sprayInterval;
            Spray();
        }
    }

    private void OnGraspEnd()
    {
        
    }

    private void Spray()
    {
        _ps.Play();
    }
}
