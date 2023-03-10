using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private int overlaps;
    public bool IsOverlapping() {
        return overlaps > 0;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Road")) {
            overlaps++;
            print(transform.localPosition);
        }
            
    }
    private void OnCollisonExit(Collision other) {
        if (other.gameObject.CompareTag("Road")) {
            overlaps--;
            print("FIXED");
        }
            
    }
}
