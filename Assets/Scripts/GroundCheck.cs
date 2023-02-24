using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public playerMovement playercontroller;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playercontroller.gameObject)
        {
            return;
        }

        playercontroller.SetGrounded(true);
    }

       private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == playercontroller.gameObject)
        {
            return;
        }

        playercontroller.SetGrounded(false);
    }

       private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == playercontroller.gameObject)
        {
            return;
        }

        playercontroller.SetGrounded(true);
    }
}
