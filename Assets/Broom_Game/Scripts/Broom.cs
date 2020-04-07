using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Broom_Game.Scripts
{
    public class Broom : MonoBehaviour
    {
        [SerializeField]
        private GameObject _broomHead;

        void Awake()
        {
            _broomHead.AddComponent<BroomHead>();
        }
    }

    public class BroomHead : MonoBehaviour
    {
        private void Start()
        {
            gameObject.AddComponent<Rigidbody>().isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var spot = other.GetComponent<Spot>();

            if (spot != null)
            {
                spot.Brush();
            }
        }
    }
}
