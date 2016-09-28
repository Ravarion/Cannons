using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject toShoot;
    public Transform spawnPos;
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            if(transform.localScale.x < 0.1f)
            {
                return;
            }
            GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
            newShot.GetComponent<Rigidbody>().AddForce(transform.forward * 20 * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
            newShot.transform.rotation = transform.rotation;
            newShot.transform.localScale = transform.localScale / 2;
            newShot.GetComponent<Rigidbody>().mass = GetComponent<Rigidbody>().mass;
            newShot.transform.FindChild("Main Camera").localPosition = new Vector3(transform.FindChild("Main Camera").localPosition.x, transform.FindChild("Main Camera").localPosition.y, transform.FindChild("Main Camera").localPosition.z-transform.localScale.z*2);
            newShot.GetComponent<MouseLook>().rotationX = GetComponent<MouseLook>().rotationX;
            newShot.GetComponent<MouseLook>().rotationY = GetComponent<MouseLook>().rotationY;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.FindChild("Main Camera").gameObject.SetActive(false);
            GetComponent<MouseLook>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            this.enabled = false;
        }
	}
}
