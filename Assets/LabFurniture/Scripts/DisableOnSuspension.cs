using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Leap.Unity;
using UnityEngine;

public class DisableOnSuspension : MonoBehaviour
{
    public bool isSuspended { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        InteractionBehaviour _ib = GetComponent<InteractionBehaviour>();
        _ib.OnSuspensionBegin += OnSuspensionBegin;
        _ib.OnSuspensionEnd += OnSuspensionEnd;
    }

    private void OnSuspensionBegin(InteractionController ic)
    {
        foreach (Transform child in transform.GetChildren())   {
            child.gameObject.SetActive(false);
        }
        isSuspended = true;
    }

    private void OnSuspensionEnd(InteractionController ic)
    {
        foreach (Transform child in transform.GetChildren())
        {
            child.gameObject.SetActive(true);
        }
        isSuspended = false;
    }
}
