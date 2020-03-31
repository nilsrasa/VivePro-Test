using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the direction vector from the camera
        Vector3 dir = (transform.position - Camera.main.transform.position).normalized;

        //Look at the point behind the canvas, because canvases are inverted
        transform.LookAt(transform.position + dir, Vector3.up);
    }

    public void Init(string name, string desc)
    {
        _nameText.text = name;
        _descriptionText.text = desc;
        gameObject.SetActive(false);
    }
}
