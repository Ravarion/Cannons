using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public Vector3 hitNormal;
	public float gravForce=1f;





	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "MainCannon") {
			hitNormal = col.transform.position-transform.position;
			col.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			//GetComponent<Rigidbody> ().drag = 0f;
			//canMove = true;
			//disable gravity, add drag
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "MainCannon" || col.gameObject.tag == "Cannon") {
			hitNormal = col.transform.position-transform.position;
			col.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			col.gameObject.GetComponent<Rigidbody> ().drag = 0f;
			hitNormal = hitNormal.normalized;
			col.gameObject.GetComponent<Rigidbody> ().AddForce (-hitNormal* gravForce, ForceMode.Impulse);
		}
		//canMove = true;
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "MainCannon" || col.gameObject.tag == "Cannon") {
			hitNormal = Vector3.up;
			col.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		}
			
		//canMove = ;
		//disable drag, add gravity
	}
}
