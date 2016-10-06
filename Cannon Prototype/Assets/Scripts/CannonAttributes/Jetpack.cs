using UnityEngine;
using System.Collections;

public class Jetpack : CannonAttribute {

    public GameObject particleEffect;

    public override void Start()
    {
        base.Start();
        if (particleEffect == null)
        {
            particleEffect = Resources.Load("Jetpack Particle") as GameObject;
        }
    }

    public override bool AHold(bool checkOverwrite)
    {
        return true;
    }

    public override void AHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }

        GameObject particles = Instantiate(particleEffect, transform.position - transform.up*1.5f*transform.localScale.x, Quaternion.Euler(90,0,0)) as GameObject;
        particles.transform.localScale = transform.localScale;
        particles.transform.parent = transform;

        Vector3 forwardMovement = new Vector3(0, 1, 0);
        if (GetComponent<Rigidbody>().velocity.y >= 5)
        {
            GetComponent<Rigidbody>().AddForce(forwardMovement * -0.1f, ForceMode.Impulse);
        }
        GetComponent<Rigidbody>().AddForce(forwardMovement * 0.1f, ForceMode.Impulse);
    }
}
