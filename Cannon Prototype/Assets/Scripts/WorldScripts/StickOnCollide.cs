using UnityEngine;
using System.Collections;

public class StickOnCollide : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Sticky")
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
}
