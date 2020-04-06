using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;

public class Gaze_Highlight : MonoBehaviour, IGazeFocusable
{
    [Header("Highlight")]
    [SerializeField, Tooltip("The color of the highlight")]
    private Color _color = Color.white;
    [SerializeField, Tooltip("The width of the highlight contour"), Range(0.01f, 2f)]
    private float _lineWidth = .2f;
    [SerializeField, Tooltip("The meshfilter of the object containing the mesh (if found elsewhere)")]
    private MeshFilter _mesh;

    private GameObject _highlight;
    public void GazeFocusChanged(bool hasFocus)
    {
        _highlight.SetActive(hasFocus);
    }

    private void Start()
    {
        InitHighlight();
    }

    private void InitHighlight()
    {
        //Instantiation the gameobject
        _highlight = new GameObject("Highlight");
        //Adding the meshfilter and copying the mesh from the original object
        _highlight.AddComponent<MeshFilter>().mesh = 
            (_mesh == null) ? GetComponent<MeshFilter>().mesh : _mesh.mesh;
        //Setting up the highlight material
        Material mat = Gaze_Settings.HighlightMaterial;
        mat.SetColor("g_vOutlineColor", _color);
        mat.SetFloat("g_flOutlineWidth", _lineWidth / 100f);
        _highlight.AddComponent<MeshRenderer>().material = mat;
        //Setting the transform parent and zeroing it's rot and pos
        _highlight.transform.SetParent(transform);
        _highlight.transform.localPosition = Vector3.zero;
        _highlight.transform.localRotation = Quaternion.identity;
        //Disable the gameobject
        _highlight.SetActive(false);
    }
}
