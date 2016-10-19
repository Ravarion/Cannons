using UnityEngine;
using System.Collections;

public class Glider : CannonAttribute {

    public float liftForce = 0.5f;
    public bool glideBreak = false;

    //Provides constant upward Force to slow desent
    void FixedUpdate()
    {

        //print(GetComponent<Rigidbody>().velocity.ToString());
        //print(transform.forward.ToString());

        if(glideBreak == false)
        {
            GliderYaw(GetComponent<Rigidbody>());
            GetComponent<Rigidbody>().AddForce(Vector3.up * liftForce);
        }
    }

    //stops glide force on collision
    //NOT IMPLEMENTED!
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Pellet")
        {
            glideBreak = true;
        }
        
//        gameObject.AddComponent<CannonAttribute>();
//        Destroy(this);
    }

    void GliderYaw(Rigidbody rig)
    {
        float mag = Mathf.Sqrt(rig.velocity.x * rig.velocity.x + rig.velocity.z * rig.velocity.z);
        Vector3 norm = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;

        rig.velocity = new Vector3(mag * norm.x, rig.velocity.y, mag * norm.z);
    }
}
