using UnityEngine;
using System.Collections;

public class CannonAttribute : MonoBehaviour {

    public GameObject toShoot;
    public Transform spawnPos;

    virtual public void Start()
    {
        if (spawnPos == null)
        {
            spawnPos = transform.FindChild("Cylinder").FindChild("SpawnPoint").transform;
        }
        if(toShoot == null)
        {
            toShoot = Resources.Load("Prefabs/Cannon") as GameObject;
        }
    }

    virtual public void LeftStickMovement(float x, float y)
    {
        if(!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        Vector3 movementDirection = new Vector3(transform.forward.x, 0, transform.forward.z) * y + new Vector3(transform.right.x, 0, transform.right.z) * x;
        GetComponent<Rigidbody>().AddForce(movementDirection * 0.1f, ForceMode.Impulse);
    }
    virtual public void RightStickMovement(float x, float y)
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        Quaternion rotation = Quaternion.Euler(new Vector3(0, x, 0) * 18 * Time.deltaTime);

        transform.Rotate(new Vector3(0, x, 0), 18 * Time.deltaTime);
        //Not used yet.  Currently using MouseLook script
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
            //Switch next object on
            cannonArray[switchIndex].transform.FindChild("Main Camera").gameObject.SetActive(true);
            cannonArray[switchIndex].GetComponent<MouseLook>().enabled = true;
            cannonArray[switchIndex].GetComponent<PlayerController>().currentCannon = true;
            //Switch current object off
            GetComponent<PlayerController>().currentCannon = false;
            transform.FindChild("Main Camera").gameObject.SetActive(false);
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<MouseLook>().enabled = false;
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

    virtual public void BDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void BUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void BHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void XDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void XUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void XHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void YDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void YUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void YHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void LeftBumperDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void LeftBumperUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void LeftBumperHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void RightBumperDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void RightBumperUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void RightBumperHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void LeftTriggerDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void LeftTriggerUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void LeftTriggerHold()
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
        if (transform.localScale.x < 0.1f)
        {
            return;
        }
        GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
        newShot.GetComponent<Rigidbody>().AddForce(transform.forward * 20 * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
        newShot.transform.rotation = transform.rotation;
        newShot.transform.localScale = transform.localScale / 2;
        newShot.GetComponent<Rigidbody>().mass = GetComponent<Rigidbody>().mass;
        newShot.transform.FindChild("Main Camera").localPosition = new Vector3(transform.FindChild("Main Camera").localPosition.x, transform.FindChild("Main Camera").localPosition.y, transform.FindChild("Main Camera").localPosition.z - transform.localScale.z * 2);
        newShot.GetComponent<MouseLook>().rotationX = GetComponent<MouseLook>().rotationX;
        newShot.GetComponent<MouseLook>().rotationY = GetComponent<MouseLook>().rotationY;
        transform.FindChild("Main Camera").gameObject.SetActive(false);
        GetComponent<MouseLook>().enabled = false;
        GetComponent<PlayerController>().currentCannon = false;
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

    virtual public void StartDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void StartUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void StartHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }

    virtual public void SelectDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void SelectUp()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
    virtual public void SelectHold()
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
    virtual public bool BDown(bool checkOverwrite){return false;}
    virtual public bool BUp(bool checkOverwrite){return false;}
    virtual public bool BHold(bool checkOverwrite){return false;}
    virtual public bool XDown(bool checkOverwrite){return false;}
    virtual public bool XUp(bool checkOverwrite){return false;}
    virtual public bool XHold(bool checkOverwrite){return false;}
    virtual public bool YDown(bool checkOverwrite){return false;}
    virtual public bool YUp(bool checkOverwrite){return false;}
    virtual public bool YHold(bool checkOverwrite){return false;}
    virtual public bool LeftBumperDown(bool checkOverwrite){return false;}
    virtual public bool LeftBumperUp(bool checkOverwrite){return false;}
    virtual public bool LeftBumperHold(bool checkOverwrite){return false;}
    virtual public bool RightBumperDown(bool checkOverwrite){return false;}
    virtual public bool RightBumperUp(bool checkOverwrite){return false;}
    virtual public bool RightBumperHold(bool checkOverwrite){return false;}
    virtual public bool LeftTriggerDown(bool checkOverwrite){return false;}
    virtual public bool LeftTriggerUp(bool checkOverwrite){return false;}
    virtual public bool LeftTriggerHold(bool checkOverwrite){return false;}
    virtual public bool RightTriggerDown(bool checkOverwrite){return false;}
    virtual public bool RightTriggerUp(bool checkOverwrite){return false;}
    virtual public bool RightTriggerHold(bool checkOverwrite){return false;}
    virtual public bool StartDown(bool checkOverwrite){return false;}
    virtual public bool StartUp(bool checkOverwrite){return false;}
    virtual public bool StartHold(bool checkOverwrite){return false;}
    virtual public bool SelectDown(bool checkOverwrite){return false;}
    virtual public bool SelectUp(bool checkOverwrite){return false;}
    virtual public bool SelectHold(bool checkOverwrite){return false;}
}
