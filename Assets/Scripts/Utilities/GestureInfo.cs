using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ViveHandTracking;

public class GestureInfo : MonoBehaviour
{
    public GameObject leftRay, rightRay;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GestureProvider.Status == GestureStatus.Running)
        {
            string left = "null";
            string right = "null";

            if (GestureProvider.LeftHand != null)
            {
                left = GestureProvider.LeftHand.gesture.ToString();
                //leftRay.SetActive(GestureProvider.LeftHand.gesture == GestureType.Point);
            }
            else
            {
                leftRay.SetActive(false);
            }

            if (GestureProvider.RightHand != null)
            {
                right = GestureProvider.RightHand.gesture.ToString();
                //rightRay.SetActive(GestureProvider.RightHand.gesture == GestureType.Point);
            }
            else
            {
                rightRay.SetActive(false);
            }

            string s = $"Left hand is doing: {left} \n right hand is doing: {right}";
            text.text = s;
        }
    }
}
