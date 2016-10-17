using UnityEngine;
using System.Collections;

public class Bouncy : CannonAttribute {

    public float jumpForce = 100.0f;
    private bool canJump;

    //allows cannon to jump if it's in constant collision with something
    void OnCollisionStay(Collision col)
    {
        canJump = true; 
    }

    //prevents jumping when cannon is not colliding with anything
    void OnCollisionExit(Collision col)
    {
        canJump = false;
    }

    //causes cannon to jump when virtual 'A' is pressed down
    public override void ADown()
    {
        if (canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
}