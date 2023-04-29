using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float movementSpeed= 10f;
    [SerializeField] private float distanceThreshold= .1f;

    private Transform currentWaypoint;

    void Start()
    {
      //set initial position to first waypoint
      currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
      transform.position = currentWaypoint.position;

      //set next waypoint target
      currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }


    void Update()
    { 
      //moves the 
      transform.position = Vector3.MoveTowards(transform.position,currentWaypoint.position,movementSpeed*Time.deltaTime);

      if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
      {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
      }
    }

   
}
