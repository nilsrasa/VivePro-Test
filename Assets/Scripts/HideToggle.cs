using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HideToggle : MonoBehaviour
{
    public SteamVR_Action_Boolean toggleAction;

    public Hand hand;

    private bool _isHidden;
    private void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (toggleAction == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> No toggle action assigned", this);
            return;
        }

        toggleAction.AddOnChangeListener(OnToggleActionChange, hand.handType);
    }

    private void OnDisable()
    {
        if (toggleAction != null)
            toggleAction.RemoveOnChangeListener(OnToggleActionChange, hand.handType);
    }

    private void OnToggleActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
    {
        if (newValue)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        _isHidden = !_isHidden;
        foreach(Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = !_isHidden;
        }
    }
}
