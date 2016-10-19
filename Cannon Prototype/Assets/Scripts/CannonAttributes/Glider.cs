using UnityEngine;
using System.Collections;

public class Glider : CannonAttribute {

    private float liftForce = 0.15f;
    private GameObject gliderWings;
    private GameObject gliderWingsFab;
    public bool glideBreak = false;
    public bool toggledOff = false;

    public override void Start()
    {
        base.Start();
        gliderWingsFab = Resources.Load("GliderWings") as GameObject;
        gliderWings = Instantiate(gliderWingsFab, transform.position, transform.rotation) as GameObject;
        gliderWings.transform.SetParent(transform);
    }

    //Provides constant upward Force to slow desent
    void FixedUpdate()
    {
        if(toggledOff == false && !GetComponent<PlayerController>().isGrounded)
        {
            GliderYaw(GetComponent<Rigidbody>());
            float downVel = GetComponent<Rigidbody>().velocity.y;
            GetComponent<Rigidbody>().AddForce(Vector3.up * -downVel - Vector3.up * liftForce);
        }
    }

    public override bool ADown(bool checkOverwrite)
    {
        return true;
    }

    public override void ADown()
    {
        Toggle(!toggledOff);
    }

    void Toggle(bool toggleOff)
    {
        toggledOff = toggleOff;
        if (toggledOff)
        {
            gliderWings.SetActive(false);
        }
        else
        {
            gliderWings.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Pellet")
        {
            Toggle(true);
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
