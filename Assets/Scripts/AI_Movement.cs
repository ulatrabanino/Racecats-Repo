using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
  
   
   //list of waypoint objects
    public List<GameObject> waypoints;
    //speed that can be changed in unity 
    public float speed  = 3f;
    //index for waypoint counter
    int index = 0; 

    // Update is called once per frame
    void Update()
    {
    
      //gets destination from waypoint index
      Vector3 destination = waypoints[index].transform.position;

      //creates a new vector3 using movetowards function to transform posiiton of current waypoint object is at to the next waypoint
      Vector3 newPos = Vector3.MoveTowards(transform.position,destination, speed*Time.deltaTime);
      transform.position = newPos;

      //gets the distance between the position its at and the destinatino which it is going to go to
      float distance = Vector3.Distance(transform.position,destination);

      //checks for distance between waypoints
      if(distance <=0.05)
      {
        //stops if theres no more waypoints in the index
        if(index<waypoints.Count-1)
        {
          index++;
        }

    }

  
}
}
