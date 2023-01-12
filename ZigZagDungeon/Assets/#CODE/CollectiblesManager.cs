using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CollectiblesManager : MonoBehaviour
{
 [SerializeField] [Range(0.01f, 1f)] public float chanceForCollectible;

 

    [SerializeField] GameObject monster;
    [SerializeField] GameObject collectible;


    /**/
    private void Start()
    {
      //  CheckIfSpawnAllowed();
     //   Debug.Log(CheckIfSpawnAllowed());
    }
   /* public bool CheckIfSpawnAllowed(bool spawn)
    {


        float temp = Random.Range(0.01f, 1f);

        if (temp < chanceForCollectible)
        {

            return spawn = true;
        }
        else
        {

            return false;
        }

    }
   */
  /*  public GameObject ObjectToSpawn()
    {
        int temp = Random.Range(0, 2);

        if (temp == 0) return collectible;
        else return monster;
    }
  */
}
