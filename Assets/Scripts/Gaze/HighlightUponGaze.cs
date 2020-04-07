using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;

public class HighlightUponGaze : MonoBehaviour, IGazeFocusable
{
    [Header("Highlight")]
    [SerializeField, Tooltip("The color of the highlight")]
    private Color _color = Color.white;
    [SerializeField, Tooltip("The width of the highlight contour"), Range(0.01f, 2f)]
    private float _lineWidth = .2f;
    [SerializeField, Tooltip("The meshfilter/s of the object/s containing the mesh/es (if found elsewhere)")]
    private MeshFilter[] _meshFilters;

    private GameObject _highlight;
    private bool _isHighlighted;
    public bool IsHighlighted { get { return _isHighlighted; } }
    public void GazeFocusChanged(bool hasFocus)
    {
        _highlight.SetActive(hasFocus);
        _isHighlighted = hasFocus;
    }

    private void Start()
    {
        InitHighlight();
    }

    private void InitHighlight()
    {
        //Instantiation the gameobject
        _highlight = new GameObject("Highlight");

        Mesh mesh;
        switch (_meshFilters.Length)
        {
            case 0:
                mesh = GetComponent<MeshFilter>().mesh;
                break;

            case 1:
                mesh = _meshFilters[0].mesh;
                break;

            default:
                mesh = CombinedMeshes();
                break;
        }
        //Adding the meshfilter and copying the mesh from the original object
        _highlight.AddComponent<MeshFilter>().mesh = mesh;
        //Setting up the highlight material
        Material mat = GazeSettings.HighlightMaterial;
        mat.SetColor("g_vOutlineColor", _color);
        mat.SetFloat("g_flOutlineWidth", _lineWidth / 100f);
        _highlight.AddComponent<MeshRenderer>().material = mat;
        //Setting the transform parent and zeroing it's rot and pos
        _highlight.transform.SetParent(transform);
        if (_meshFilters.Length < 1)//fixes problem where combined meshes reset origin
        {
            _highlight.transform.localPosition = Vector3.zero;
            _highlight.transform.localRotation = Quaternion.identity;
        }
        //Remember to reset scale!
        _highlight.transform.localScale = Vector3.one;
        //Disable the gameobject
        _highlight.SetActive(false);
    }

    private Mesh CombinedMeshes()
    {
        Mesh mesh = new Mesh();
        CombineInstance[] combine = new CombineInstance[_meshFilters.Length];

        for (int i = 0; i < combine.Length; i++){
            combine[i].mesh = _meshFilters[i].sharedMesh;
            combine[i].transform = _meshFilters[i].transform.localToWorldMatrix;
        }

        mesh.CombineMeshes(combine);
        return mesh;
    }
}
