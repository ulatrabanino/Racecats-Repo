using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float terrainMinValueX = -275f;
    private float terrainMaxValueX = 281f;
    private float terrianValueY = -5.41f;
    private float terrainMinValueZ = -172f;
    private float terrainMaxValueZ = 287f;
    public bool onRoad = true;

    void Update() {
        if (onRoad) {
            //create Ray object
            Ray downwardsRay = new Ray(transform.position + new Vector3(0,5,0), Vector3.down);
            //draw Ray
            Debug.DrawRay(transform.position + new Vector3(0,5,0), Vector3.down * 5f, Color.white);
            //if ray collides with Road tagged as environment
            if (Physics.Raycast(downwardsRay, out RaycastHit hit, 5f)) {
                if (hit.collider.tag == "Road") {
                    transform.localPosition = new Vector3(Random.Range(terrainMinValueX, terrainMaxValueX), terrianValueY, Random.Range(terrainMinValueZ, terrainMaxValueZ));
                } else {
                    onRoad = false;
                }
            } else {
                onRoad = false;
            }
        }
    }
}
