using UnityEngine;
using System.Collections;

public class CannonAttribute : MonoBehaviour {

    public GameObject toShoot;
    public Transform spawnPos;
    public float blowback = 1;
    public AudioClip cannonFireSound;
    public AudioClip deathSound;

	public bool canMove = true;
	public Vector3 hitNormal;

    virtual public void Start()
    {
        if (spawnPos == null)
        {
            spawnPos = transform.FindChild("Cylinder").FindChild("SpawnPoint").transform;
        }
        if (!deathSound)
        {
            deathSound = Resources.Load("Sounds/death") as AudioClip;
        }
        if (!cannonFireSound)
        {
            cannonFireSound = Resources.Load("Sounds/cannonBlast") as AudioClip;
        }
    }

    virtual public void Update()
    {
        //Place holder
    }

    virtual public void PlayCannonFireSound()
    {
        if(cannonFireSound)
        {
            GetComponent<AudioSource>().clip = cannonFireSound;
            GetComponent<AudioSource>().Play();
        }
    }

    virtual public void PlayDeathSound()
    {
        if (deathSound)
        {
            GetComponent<AudioSource>().clip = deathSound;
            GetComponent<AudioSource>().Play();
        }
    }

	void OnCollisionEnter(Collision col)
	{
		hitNormal = col.contacts [0].normal;
		canMove = true;
	}

	void OnCollisionStay(Collision col)
	{
		hitNormal = col.contacts [0].normal;
		canMove = true;
	}

	void OnCollisionExit(Collision col)
	{
		hitNormal = Vector3.up;
		canMove = false;
	}

    virtual public void SwitchTo(GameObject cannon)
    {
        //Switch current object off
        transform.FindChild("Main Camera").gameObject.SetActive(false);
        GetComponent<PlayerController>().currentCannon = false;
        GetComponent<MouseLook>().enabled = false;
        //Switch next object on
        cannon.transform.FindChild("Main Camera").gameObject.SetActive(true);
        cannon.GetComponent<PlayerController>().currentCannon = true;
        cannon.GetComponent<MouseLook>().enabled = true;
    }

    virtual public void LeftStickMovement(float x, float y)
    {
        if(!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        if(!GetComponent<PlayerController>().isGrounded)
        {
            return;
        }
        /**Patrick's Movement
        //Vector3 movementDirection = new Vector3(transform.forward.x, 0, transform.forward.z) * y + new Vector3(transform.right.x, 0, transform.right.z) * x;
        //GetComponent<Rigidbody>().AddForce(movementDirection * 0.1f, ForceMode.Impulse);*/

        /**Marcus's Movement*/
		Vector3 movementDirection = new Vector3 (transform.forward.x, 0, transform.forward.z) * y + new Vector3 (transform.right.x, 0, transform.right.z) * x;
		movementDirection = Vector3.ProjectOnPlane (movementDirection, hitNormal);
        //Vector3 movementDirection = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z) * y + new Vector3(transform.right.x, transform.right.y, transform.right.z) * x;
        //movementDirection = new Vector3(transform.forward.x,0,transform.forward.z) * y + new Vector3(transform.forward.x,0,transform.forward.z) * x;
        GetComponent<Rigidbody> ().AddForce (movementDirection * 0.1f, ForceMode.Impulse);
    }
    virtual public void RightStickMovement(float x, float y)
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void DPadMovement(float x, float y)
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }

        //If left or right is pressed
        if (x <= -0.5 || x >= 0.5)
        {
            int switchIndex = 0;
            GameObject[] cannonArray = GameObject.FindGameObjectsWithTag("Cannon");

            if (x >= 0.5)
            {
                //Switch Mechanic
                if (cannonArray.Length <= 1)
                {
                    return;
                }
                for (int i = 0; i < cannonArray.Length; i++)
                {
                    if (gameObject == cannonArray[i])
                    {
                        if (i == cannonArray.Length - 1)
                        {
                            switchIndex = 0;
                        }
                        else
                        {
                            switchIndex = i + 1;
                        }
                    }
                }
            }
            else if(x <= -0.5)
            {
                //Switch Mechanic
                if (cannonArray.Length <= 1)
                {
                    return;
                }
                for (int i = cannonArray.Length - 1; i >= 0; i--)
                {
                    if (gameObject == cannonArray[i])
                    {
                        if (i == 0)
                        {
                            switchIndex = cannonArray.Length - 1;
                        }
                        else
                        {
                            switchIndex = i - 1;
                        }
                    }
                }
            }
            SwitchTo(cannonArray[switchIndex]);
        }
    }

    virtual public void ADown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void AUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void AHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void RightTriggerDown()
    {
        if(!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        if(!toShoot)
        {
            return;
        }
        PlayCannonFireSound();
        GetComponent<Rigidbody>().AddForce(transform.forward * blowback);
        GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
        newShot.GetComponent<Rigidbody>().AddForce(transform.forward * 20 * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
        newShot.transform.rotation = transform.rotation;
    }
    virtual public void RightTriggerUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void RightTriggerHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public bool LeftStickMovement(bool checkOverwrite){return false;}
    virtual public bool RightStickMovement(bool checkOverwrite){return false;}
    virtual public bool DPadMovement(bool checkOverwrite){return false;}
    virtual public bool ADown(bool checkOverwrite){return false;}
    virtual public bool AUp(bool checkOverwrite){return false;}
    virtual public bool AHold(bool checkOverwrite){return false;}
    virtual public bool LeftTriggerDown(bool checkOverwrite){return false;}
    virtual public bool LeftTriggerUp(bool checkOverwrite){return false;}
    virtual public bool LeftTriggerHold(bool checkOverwrite){return false;}
    virtual public bool RightTriggerDown(bool checkOverwrite){return false;}
    virtual public bool RightTriggerUp(bool checkOverwrite){return false;}
    virtual public bool RightTriggerHold(bool checkOverwrite){return false;}
}
