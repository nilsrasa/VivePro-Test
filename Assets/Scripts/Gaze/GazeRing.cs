using System.Collections;
using System.Collections.Generic;
using Tobii.XR;
using UnityEngine;
using UnityEngine.UI;

public class GazeRing : MonoBehaviour
{
    private static GazeRing _instance;
    public static GazeRing Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private float _progress;

    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = _progress;
    }

    public void SetProgress(float pct)
    {
        _progress = pct;

        TobiiXR_GazeRay gaze = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World).GazeRay;
        RaycastHit hit;
        if (Physics.Raycast(gaze.Origin, gaze.Direction, out hit))
        {
            transform.position = hit.point;
        }

    }

    public void Hide()
    {
        _progress = 0;
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
