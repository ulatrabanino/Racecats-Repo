using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;


    [Range(0f,15)] //How fast Ai will rotate once it reaches its waypoint 
    [SerializeField] private float movementSpeed= 10f;

    [SerializeField] private float rotateSpeed =4f;
    [SerializeField] private float distanceThreshold= .1f;

    private Transform currentWaypoint;

    //the rotation target for the current frame
    private Quaternion rotationGoal; //end goal rotation we want to get to 

    //the direction to next waypoint that ai needs to rotate towards
    private Vector3 directionToWaypoint;

    //holds variant speeds of enemy racer
    private float[] speedArray;

    void Start() {
        //set initial position to first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //set next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

        speedArray = new[] { 5f, 10f, 15f, 20f, 25f, 30f};

        //changes enemy racer speed every second
        InvokeRepeating("ChangeSpeed", 0.0f, 2.0f);
    }


    void Update() { 
        //moves the 
        transform.position = Vector3.MoveTowards(transform.position,currentWaypoint.position,movementSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

        }
        //called everyframe
        RotateTowardsWaypoint();
    }


    //Will slowly rotate A.I. towards the current waypoint it is moving towards

    private void RotateTowardsWaypoint() {

        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;

        rotationGoal = Quaternion.LookRotation(directionToWaypoint);

    //slerp does a full rotation spherically
        transform.rotation = Quaternion.Slerp(transform.rotation,rotationGoal,rotateSpeed*Time.deltaTime);

    }

    //changes movementSpeed to random speed in speedArray
    private void ChangeSpeed() {
        System.Random rand = new System.Random();
        int randomIndex = rand.Next(0, speedArray.Length);
        float randomSpeed = speedArray[randomIndex];
        movementSpeed = randomSpeed;
    }
}
