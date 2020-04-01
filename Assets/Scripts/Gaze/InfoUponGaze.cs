using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;

public class InfoUponGaze : MonoBehaviour, IGazeFocusable
{
    [SerializeField] private Material _highlightMat;
    [SerializeField] private InfoBox _infoBox;
    [SerializeField, TextArea(3, 5)] private string _infoMsg = "";
    [SerializeField] private float _timeOut = 2f;

    private GameObject _highlight;
    public void GazeFocusChanged(bool hasFocus)
    {
        //Hide or show highlight and infobox if gazed or not
        _highlight.SetActive(hasFocus);
        _infoBox.gameObject.SetActive(hasFocus);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitHighlight();
        //Subscribe to the infobox gaze event
        _infoBox.OnGazeFocusChanged += GazeFocusChanged;
        //Init the infobox
        _infoBox.Init(name, _infoMsg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitHighlight()
    {
        _highlight = new GameObject("Highlight");
        _highlight.AddComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
        _highlight.AddComponent<MeshRenderer>().material = _highlightMat;
        _highlight.transform.SetParent(transform);
        _highlight.transform.localPosition = Vector3.zero;
        _highlight.SetActive(false);
    }

    private void OnDestroy()
    {
        _infoBox.OnGazeFocusChanged -= GazeFocusChanged;
    }
}
