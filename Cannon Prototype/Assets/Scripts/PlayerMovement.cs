using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speedScale = 1.0f;

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forwardMovement = new Vector3(transform.forward.x, 0, transform.forward.z);
            GetComponent<Rigidbody>().AddForce(forwardMovement * speedScale);          
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 forwardMovement = new Vector3(transform.forward.x, 0, transform.forward.z);
            GetComponent<Rigidbody>().AddForce(-forwardMovement * speedScale);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 forwardMovement = new Vector3(-transform.right.x, 0, -transform.right.z);
            GetComponent<Rigidbody>().AddForce(forwardMovement * speedScale);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 forwardMovement = new Vector3(transform.right.x, 0, transform.right.z);
            GetComponent<Rigidbody>().AddForce(forwardMovement * speedScale);
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            int switchIndex = 0;
            GameObject[] cannonArray = GameObject.FindGameObjectsWithTag("Cannon");

            if (Input.GetKeyDown(KeyCode.Q))
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Switch Mechanic
                if (cannonArray.Length <= 1)
                {
                    return;
                }
                for (int i = cannonArray.Length-1; i >= 0; i--)
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
            //Switch next object on
            cannonArray[switchIndex].transform.FindChild("Main Camera").gameObject.SetActive(true);
            cannonArray[switchIndex].GetComponent<MouseLook>().enabled = true;
            //cannonArray[switchIndex].GetComponent<Shoot>().enabled = true;
            cannonArray[switchIndex].GetComponent<PlayerMovement>().enabled = true;
            //Switch current object off
            transform.FindChild("Main Camera").gameObject.SetActive(false);
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<MouseLook>().enabled = false;
            //GetComponent<Shoot>().enabled = false;
            this.enabled = false;
        }
    }
}
