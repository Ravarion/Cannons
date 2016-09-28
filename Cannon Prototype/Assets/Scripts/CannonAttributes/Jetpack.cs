using UnityEngine;
using System.Collections;

public class Jetpack : CannonAttribute {
	
    public override void AHold()
    {
        Vector3 forwardMovement = new Vector3(0, 1, 0);
        if (GetComponent<Rigidbody>().velocity.y >= 5)
        {
            GetComponent<Rigidbody>().AddForce(forwardMovement * -0.1f, ForceMode.Impulse);
        }
        GetComponent<Rigidbody>().AddForce(forwardMovement * 0.1f, ForceMode.Impulse);
    }
}
