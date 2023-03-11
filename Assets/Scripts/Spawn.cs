using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject car;
    private float terrainMinValueX;
    private float terrainMaxValueX;
    private float terrainValueY;
    private float terrainMinValueZ;
    private float terrainMaxValueZ;
    public bool onRoad = true;

    void Start() {
        terrainMinValueX = car.GetComponent<RandomSpawn>().terrainMinValueX;
        terrainMaxValueX = car.GetComponent<RandomSpawn>().terrainMaxValueX;
        terrainValueY = car.GetComponent<RandomSpawn>().terrainValueY;
        terrainMinValueZ = car.GetComponent<RandomSpawn>().terrainMinValueZ;
        terrainMaxValueZ = car.GetComponent<RandomSpawn>().terrainMaxValueZ;
    }
    void Update() {
        if (onRoad) {
            //create Ray object
            Ray downwardsRay = new Ray(transform.position + new Vector3(0,5,0), Vector3.down);

            //draw Ray
            Debug.DrawRay(transform.position + new Vector3(0,5,0), Vector3.down * 5f, Color.white);

            //if ray collides with Road tagged as environment
            if (Physics.Raycast(downwardsRay, out RaycastHit hit, 5f)) {
                if (hit.collider.tag == "Road") {
                    transform.localPosition = new Vector3(Random.Range(terrainMinValueX, terrainMaxValueX), terrainValueY, Random.Range(terrainMinValueZ, terrainMaxValueZ));
                } else {
                    onRoad = false;
                }
            } else {
                onRoad = false;
            }
        }
    }
}
