using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSettings : MonoBehaviour
{
    [Header("Highlight settings")]
    [SerializeField, Tooltip("The base material used for drawing highlights")]
    private Material _highlightMaterial;
    public static Material HighlightMaterial 
    { 
        get { return new Material(_instance._highlightMaterial); } 
    }

    private static GazeSettings _instance;
    public static GazeSettings Instance
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
