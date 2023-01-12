using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTileOnCamViewExit : MonoBehaviour
{

    PathGenerator pathGenerator;
    [SerializeField] float delay = 1f;

    private void Start()
    {
        pathGenerator = FindObjectOfType<PathGenerator>();
    }
    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Tile"))
        {
            Invoke(nameof(UpdatePath), delay);
           
        }
    }

    void UpdatePath()
    {
        pathGenerator.UpdatePath();
    }

}
