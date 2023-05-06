using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
    //drawing out waypoint script for objects to follow in a loop 
    private void OnDrawGizmos() {   
        //draws spheres created so object has path, which are the waypoints
        foreach(Transform t in transform) {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position,1f);
        }
        
        //draws lines of red indicating where its going from the spheres
        Gizmos.color = Color.red;
        for(int i=0; i<transform.childCount-1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).position,transform.GetChild(i+1).position);
        }

        //draws loop between the waypoints essentially goes back to childobject[0]
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position,transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint) {

        //if no waypoints exist go to first one
        if(currentWaypoint == null) {
            return transform.GetChild(0);
        }

        //if this waypoint is anything but the last one then +1 and its the correct waypoint
        if(currentWaypoint.GetSiblingIndex() < transform.childCount -1) {
            return transform.GetChild(currentWaypoint.GetSiblingIndex()+1);
        }

        //if its last waypoint return first one
        else {
            return transform.GetChild(0);
        }
    }
}
