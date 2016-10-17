using UnityEngine;
using System.Collections;

public class Glider : CannonAttribute {

    public float liftForce = 0.5f;
    private bool glideBreak = false;

    //Provides constant upward Force to slow desent
    void FixedUpdate()
    {
        if(glideBreak == false)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * liftForce);
        }
    }

    //stops glide force on collision
    //NOT IMPLEMENTED!
    void OnCollisionEnter(Collision col)
    {
//        gameObject.AddComponent<CannonAttribute>();
//        Destroy(this);
    }
}
