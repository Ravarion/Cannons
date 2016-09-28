using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 forwardMovement = new Vector3(0, 1, 0);
            if (GetComponent<Rigidbody>().velocity.y >=5)
            {
                GetComponent<Rigidbody>().AddForce(forwardMovement * -0.1f, ForceMode.Impulse);
            }
            GetComponent<Rigidbody>().AddForce(forwardMovement * 0.1f, ForceMode.Impulse);
        }
    }
}
