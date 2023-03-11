using EasyRoads3Dv3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject spawn;
    private int spawnNum = 20;

    [HideInInspector]
    public float terrainMinValueX = -198f;
    public float terrainMaxValueX = 216f;
    public float terrainValueY = -5.41f;
    public float terrainMinValueZ = -70f;
    public float terrainMaxValueZ = 219f;

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

    //creates and spawns new object
    private void SpawnObject() {
        Vector3 objectPosition = new Vector3(Random.Range(terrainMinValueX, terrainMaxValueX), terrainValueY, Random.Range(terrainMinValueZ, terrainMaxValueZ));
        var obj = Instantiate(spawn, objectPosition, Quaternion.identity, spawn.transform.parent.gameObject.transform);
        obj.transform.localPosition = objectPosition;
    }
}
