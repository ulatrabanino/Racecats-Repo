using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    AudioManager manager;
    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity, maxForce, boostspeed, boostEnergy;
    private Vector2 move,look;
    private float lookRotation;
 
    public bool grounded;

    //min values and max for rotating camera
    [SerializeField] private Vector3 minValue, maxValue;

    private SpriteRenderer spriteRenderer;
    public Sprite catCarSprite;
    public Sprite catCarLeftSprite;
    public Sprite catCarRightSprite;
    private int catCarSpriteValue = 0;
    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>();
        //manager.Play("CarDrive");
    }

    public void OnLook(InputAction.CallbackContext context) {
        look =context.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        Move();
    }

    void Move() {
        
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x,rb.velocity.y, move.y);

        //checks if spacebar is held then speed boost is applied, otherwise normal movement speed is applied
        if(Input.GetKey(KeyCode.Space)) {
            boostEnergy = gameObject.GetComponent<BoostEnergy>().energy;

            //spacebar pressed = boostspeed for increase if enough energy is left
            if (boostEnergy > 0) {
                targetVelocity *= boostspeed;
            }
            //normal speed if no energy left
            else {
                targetVelocity *= speed;
            }
        }

        //otherwise normal speed increase when holding w 
        else {   
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
        transform.Rotate(Vector3.up*look.x * sensitivity);
        //look around
        lookRotation +=(-look.y*sensitivity);
        lookRotation = Mathf.Clamp(lookRotation,minValue.y,maxValue.z);//clamps look rotation so it wont have weird looking angles
        camHolder.transform.eulerAngles = new Vector3(lookRotation,camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<AudioManager>();
        manager.Play("RacetrackBGM");

        if(SceneManager.GetActiveScene().name == "Racetrack 1") {
            manager.Play("DesertWindSFX");
        }
    }

    // Update is called once per frame
    void LateUpdate() {

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

    //checks to see if your on the ground 
    public void SetGrounded(bool state) {
        grounded = state;
    }
}
