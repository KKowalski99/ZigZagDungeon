using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [SerializeField] GameObject tile;


    /* set toprivate after test*/
    [SerializeField] List<GameObject> tiles = new List<GameObject>();
   static Vector3 startingVector = new Vector3(-2.1f, 0, 2.8f);


    Vector3 left = new Vector3(0.7f, 0 ,0.7f);
    Vector3 right = new Vector3(-0.7f, 0, 0.7f);

  
    int lastTileIndex;

    CollectiblesManager collectiblesManager;
    //////////////////////////////////////////////////
    [SerializeField] [Range(0.01f, 1f)] public float chanceForCollectible;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject collectible;
    ////////////////////////////////////////////////////////////////////

    private void Start()
    {
      

        if (tile == null) Debug.Log("Tile object has not been attached");
        GenerateStartingPath();



     
   
    }

    void GenerateStartingPath()
    {
        var temp = Instantiate(tile, transform.position = startingVector, Quaternion.identity);
        temp.transform.SetParent(transform);
        tiles.Add(temp);

        for (int i = 0; i < 26; i++)
        {
            AddNextNode();
        }
    }

    public void UpdatePath()
    {
         AddNextNode();
        RemoveLastNode();
    }
   
 

    void AddNextNode()
    {
         lastTileIndex = tiles.Count - 1;

        var temp = Instantiate(tile, transform.position, Quaternion.identity);


         int logic = Random.Range(0, 2);


        if (logic == 1) temp.transform.position = tiles[lastTileIndex].GetComponent<Transform>().position + right;
        else temp.transform.position = tiles[lastTileIndex].GetComponent<Transform>().position + left;


        temp.transform.SetParent(transform);
        tiles.Add(temp);



        bool _temp = CheckIfSpawnAllowed();
       if (_temp == true)
        {
           GameObject tempObject = ObjectToSpawn();
            tempObject =  Instantiate(tempObject, transform.position, Quaternion.identity);
            tempObject.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y + 7, temp.transform.position.z);
            tempObject.transform.SetParent(temp.transform);

            if (logic == 1) tempObject.transform.Rotate(0, 0, 0);
            else tempObject.transform.Rotate(0, 90, 0);


        }
  

    }

    //////////////////////////DO WYJEBANIA/////////////////////////////////////

    private void Update()
    {
        Player player = FindObjectOfType<Player>();



    }
    public bool CheckIfSpawnAllowed()
    {
        float temp = Random.Range(0.01f, 1f);

        if (temp < chanceForCollectible)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject ObjectToSpawn()
    {
        int temp = Random.Range(0, 2);

        if (temp == 0) return collectible;
        else return monster;
    }
    //////////////////////////////////////////////////////////////////////////
    void RemoveLastNode()
    {

        Destroy(tiles[0]);
        tiles.Remove(tiles[0]);
    }

    

}
