using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadController : MonoBehaviour
{
    NewControls controls;

    Vector2 move, look;
    public Rigidbody rb;
    public float speed = 10, boostspeed = 30, maxForce = 2, sensitivity = .1f; 
    public static bool boosting = false;
    public GameObject camHolder;
    [SerializeField] private Vector3 minValue, maxValue;

    private float lookRotation;

    void OnEnable() {
        controls.ControllerPlayer.Enable();
    }

    void Awake()
    {
        controls = new NewControls();

        controls.ControllerPlayer.SpeedBoost.performed += ctx => boosting = true;
        controls.ControllerPlayer.SpeedBoost.canceled += ctx => boosting = false;

        controls.ControllerPlayer.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.ControllerPlayer.Move.canceled += ctx => move = Vector2.zero;
        controls.ControllerPlayer.CameraMove.performed += ctx => look = ctx.ReadValue<Vector2>() * sensitivity;
        controls.ControllerPlayer.CameraMove.canceled += ctx => look = Vector2.zero;
    }

    void FixedUpdate() {
        Move();
        Look();
    }

    void Move() {
        Debug.Log(boosting);
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x,rb.velocity.y, move.y);

        if(boosting) {
            float boostEnergy = gameObject.GetComponent<BoostEnergy>().energy;
            if (boostEnergy > 0) {
                targetVelocity *= boostspeed;
            } 
            else {
                targetVelocity *= speed;
            }
        } else {
            targetVelocity *= speed;
        }

        //align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = (targetVelocity-currentVelocity);
        velocityChange = new Vector3(velocityChange.x,0,velocityChange.z); //fixes falling so u can fall 

        //limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void Look() {
        //turn camera rotation
        transform.Rotate(Vector3.up*look.x * 5f);
        //look around
        lookRotation += (-look.y*5f);
        lookRotation = Mathf.Clamp(lookRotation,minValue.y,maxValue.z);//clamps look rotation so it wont have weird looking angles
        camHolder.transform.eulerAngles = new Vector3(lookRotation,camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }
}
