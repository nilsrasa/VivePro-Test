using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour, IGazeFocusable
{
    [SerializeField] 
    private Text _nameText;
    [SerializeField] 
    private Text _descriptionText;
    
    [SerializeField]
    private RectTransform _rectTransform;
    private BoxCollider _collider;
    private Vector3 _size, _center;
    [Tooltip("Make sure the collider is centered over the visual element.")]
    [SerializeField]
    private Vector3 _offset;

    [Tooltip("Let the collider follow the visual borders of the element as closely as possible.")]
    [SerializeField]
    private Vector3 _padding;
    private bool _hasStarted;

    public System.Action<bool> OnGazeFocusChanged;

    // Start is called before the first frame update
    void Start()
    {
        _hasStarted = true;
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
        //Set the texts
        _nameText.text = name;
        _descriptionText.text = desc;

        //Start delayed init
        StartCoroutine(DelayedInit());
    }

    private IEnumerator DelayedInit()
    {
        //Wait for until the gameobject is ready
        yield return new WaitUntil(() => _hasStarted);

        //Generate collider that fits the UI size
        _collider = GenerateRectCollider();

        //Hide
        gameObject.SetActive(false);
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        //If there's a subscriber, call the event
        if (OnGazeFocusChanged != null)
            OnGazeFocusChanged(hasFocus);
    }

    private BoxCollider GenerateRectCollider()
    {
        var collider = gameObject.AddComponent<BoxCollider>();

        _size = GetSize(_rectTransform, _padding);

        collider.size = _size;
        collider.center = CalculateCenter(_rectTransform, _offset, _size);
        collider.isTrigger = true;

        return collider;
    }

    private static Vector3 CalculateCenter(RectTransform rectTransform, Vector3 offset, Vector3 size)
    {
        var scale = rectTransform.lossyScale.z * 0.01f;
        var center = Vector3.zero + offset;

        var pivotAdjust = (Vector2.one * 0.5f - rectTransform.pivot);

        center.x += pivotAdjust.x * size.x;
        center.y += pivotAdjust.y * size.y;

        return center;
    }

    private static Vector3 GetSize(RectTransform rectTransform, Vector3 padding)
    {
        var width = rectTransform.rect.size.x;
        var height = rectTransform.rect.size.y;

        return new Vector3(width + padding.x, height + padding.y, .01f + padding.z);
    }
}
