using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopBehaviour : MonoBehaviour
{

    [SerializeField] private Material[] _screenMaterials;
    [SerializeField] private Renderer _screenRenderer;
    [SerializeField] private int _screenMatIndex;

    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        _index = 0;
        _screenRenderer.materials[_screenMatIndex] = _screenMaterials[_index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        _index = ++_index % (_screenMaterials.Length);
        Debug.Log("Next: index is " + _index);
        UpdateMaterials();
    }

    public void Prev()
    {
        _index = Mathf.Abs(--_index % (_screenMaterials.Length));
        Debug.Log("Prev: index is " + _index);
        UpdateMaterials();
    }

    private void UpdateMaterials()
    {
        Material[] materials = _screenRenderer.materials;
        materials[_screenMatIndex] = _screenMaterials[_index];
        _screenRenderer.materials = materials;
    }
}
