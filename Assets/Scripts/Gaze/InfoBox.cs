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
        
    }

    public void Init(string name, string desc)
    {
        _nameText.text = name;
        _descriptionText.text = desc;
        gameObject.SetActive(false);
    }
}
