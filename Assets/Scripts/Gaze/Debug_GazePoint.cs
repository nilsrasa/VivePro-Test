using System.Collections;
using System.Collections.Generic;
using Tobii.XR;
using UnityEngine;

public class Debug_GazePoint : MonoBehaviour
{
    Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        TobiiXR_GazeRay gaze = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World).GazeRay;
        if (gaze.IsValid)
        {
            RaycastHit hit;
            if (Physics.Raycast(gaze.Origin, gaze.Direction, out hit))
            {
                _renderer.enabled = true;
                transform.position = hit.point;
            }
            else
            {
                _renderer.enabled = false;
            }
        }
        else
        {
            _renderer.enabled = false;
        }
    }
}
