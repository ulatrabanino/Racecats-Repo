using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity,maxForce, jumpForce;
    private Vector2 move,look;
    private float lookRotation;

    public bool grounded;

    private SpriteRenderer spriteRenderer;
    public Sprite catCarSprite;
    public Sprite catCarLeftSprite;
    public Sprite catCarRightSprite;
    private int catCarSpriteValue = 0;
    public void OnMove(InputAction.CallbackContext context)

    {
        move =context.ReadValue<Vector2>();
    
    }

    
    public void OnLook(InputAction.CallbackContext context)

    {
        look =context.ReadValue<Vector2>();
    
    }

     public void OnJump(InputAction.CallbackContext context)

    {
        Jump();
    
    }


    private void FixedUpdate()
    {
        Move();
      
    }

    void Jump()
    {
        Vector3 jumpForces = Vector3.zero;

        if(grounded)
        {
            jumpForces  = Vector3.up * jumpForce;
        }
        rb.AddForce(jumpForces, ForceMode.VelocityChange);

    }

    void Move()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x,0, move.y);
        targetVelocity *= speed;

        //align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = (targetVelocity-currentVelocity);
        velocityChange = new Vector3(velocityChange.x,0,velocityChange.z); //fixes falling so u can fall 

        //limit force

        Vector3.ClampMagnitude(velocityChange, maxForce);
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

    }

    void Look()
    {
        //turn camera rotation
        transform.Rotate(Vector3.up*look.x * sensitivity);
        //look around
        lookRotation +=(-look.y*sensitivity);
        lookRotation = Mathf.Clamp(lookRotation,-90,90);//clamps look rotation so it wont have weird looking angles
        camHolder.transform.eulerAngles = new Vector3(lookRotation,camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        catCarSprite = StateController.carSprite;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Look();

        //changes car sprite if turning
        if (Input.GetAxisRaw("Horizontal") < 0 && catCarSpriteValue >= 0) {
            ChangeSprite(catCarLeftSprite);
            catCarSpriteValue = -1;
        } else if(Input.GetAxisRaw("Horizontal") > 0 && catCarSpriteValue <= 0) {
            ChangeSprite(catCarRightSprite);
            catCarSpriteValue = 1;
        } else if(Input.GetAxisRaw("Horizontal") == 0 && catCarSpriteValue != 0) {
            ChangeSprite(catCarSprite);
            catCarSpriteValue = 0;
        }       
    }

    //changes car sprite
    void ChangeSprite(Sprite newSprite) {
        spriteRenderer.sprite = newSprite;
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }
}
