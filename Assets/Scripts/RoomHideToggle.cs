using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RoomHideToggle : MonoBehaviour
{
    public SteamVR_Action_Boolean toggleAction;

    public Hand hand;

    public GameObject transparentRoom, solidRoom;

    private enum State
    {
        Solid,
        Transparent,
        Hidden
    }

    private State _state = State.Solid;
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

    private void Update()
    {
        
    }

    private void Toggle()
    {
        if (++_state > State.Hidden)
            _state = State.Solid;

        solidRoom.SetActive(_state == State.Solid);
        transparentRoom.SetActive(_state == State.Transparent);

        
    }
}
