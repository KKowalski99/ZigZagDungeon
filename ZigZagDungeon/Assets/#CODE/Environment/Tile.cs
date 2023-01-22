using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class Tile : MonoBehaviour
    {
        Rigidbody rb;
        PathGenerator pathGenerator;
        [SerializeField] float fallDelay = 0.5f;
        [SerializeField] float updateDelay = 0.5f;
        private void Start()
        {
            BoxCollider collider = GetComponentInChildren<BoxCollider>();
            OnTriggerExit(collider);

            rb = GetComponent<Rigidbody>();
            pathGenerator = FindObjectOfType<PathGenerator>();
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Invoke(nameof(StartToFall), fallDelay);

            }
        }

        void StartToFall()
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            Invoke(nameof(CallPathUpdate), updateDelay);
        }

        private void CallPathUpdate()
        {
            pathGenerator.UpdatePath();


        }
    }
}