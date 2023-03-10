using EasyRoads3Dv3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject spawn;
    //private List<GameObject> spawns = new List<GameObject>();
    private int spawnNum = 50;
    private float terrainMinValueX = -275f;
    private float terrainMaxValueX = 281f;
    private float terrianValueY = -5.41f;
    private float terrainMinValueZ = -172f;
    private float terrainMaxValueZ = 287f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnNum; i++) {
            SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject() {
        //creates and spawns new object
        Vector3 objectPosition = new Vector3(Random.Range(terrainMinValueX, terrainMaxValueX), terrianValueY, Random.Range(terrainMinValueZ, terrainMaxValueZ));
        var obj = Instantiate(spawn, objectPosition, Quaternion.identity, spawn.transform.parent.gameObject.transform);
        obj.transform.localPosition = objectPosition;
            
        //if object is on road, assign new position
        while(obj.GetComponent<Spawn>().IsOverlapping()) {
            objectPosition = new Vector3(Random.Range(terrainMinValueX, terrainMaxValueX), terrianValueY, Random.Range(terrainMinValueZ, terrainMaxValueZ));
            obj.transform.localPosition = objectPosition;
         }
            
         //spawns.Add(obj);
    }
}
