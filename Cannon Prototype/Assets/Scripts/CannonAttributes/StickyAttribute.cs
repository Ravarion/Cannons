using UnityEngine;
using System.Collections;

public class StickyAttribute : CannonAttribute {

    void OnCollisionEnter(Collision col)
	{
		hitNormal = col.contacts [0].normal;
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Rigidbody> ().drag = 4f;
		canMove = true;
		//disable gravity, add drag
	}

	void OnCollisionStay(Collision col)
	{
		hitNormal = col.contacts [0].normal;
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Rigidbody> ().drag = 4f;
		canMove = true;
	}

	void OnCollisionExit(Collision col)
	{
		hitNormal = Vector3.up;
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Rigidbody> ().drag = 0f;
		canMove = false;
		//disable drag, add gravity
	}

    public override bool LeftStickMovement(bool checkOverwrite)
    {
        return true;
    }

    public override void LeftStickMovement(float x, float y)
	{
		if (canMove) {
			if (!GetComponent<PlayerController> ().currentCannon) {
				return;
			}
			//Vector3 movementDirection = new Vector3(transform.forward.x, 0, transform.forward.z) * y + new Vector3(transform.right.x, 0, transform.right.z) * x;

			Vector3 movementDirection = new Vector3 (transform.forward.x, transform.forward.y, transform.forward.z) * y + new Vector3 (transform.right.x, transform.right.y, transform.right.z) * x;

			movementDirection = Vector3.ProjectOnPlane (movementDirection, hitNormal);

			//movementDirection = new Vector3(transform.forward.x,0,transform.forward.z) * y + new Vector3(transform.forward.x,0,transform.forward.z) * x;

			GetComponent<Rigidbody> ().AddForce (movementDirection * 0.1f, ForceMode.Impulse);
		}
	}
}
