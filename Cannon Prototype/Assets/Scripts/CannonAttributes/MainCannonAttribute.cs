using UnityEngine;
using System.Collections;

public class MainCannonAttribute : CannonAttribute {

    public GameObject leftAttributeToSend;
    public GameObject rightAttributeToSend;

    override public void Start()
    {
        base.Start();
        if (toShoot == null)
        {
            toShoot = Resources.Load("SubCannon") as GameObject;
        }
    }
    override public void RightTriggerDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        if (transform.localScale.x < 0.1f)
        {
            return;
        }
        GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
        //Add attributes
        if(leftAttributeToSend != null)
        {
            newShot.AddComponent(leftAttributeToSend.GetComponent<CannonAttribute>().GetType());
        }
        if (rightAttributeToSend != null)
        {
            newShot.AddComponent(rightAttributeToSend.GetComponent<CannonAttribute>().GetType());
        }

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

    public void NewAttributeToSend(GameObject newAttributeObj)
    {
        if (leftAttributeToSend == null)
        {
            leftAttributeToSend = newAttributeObj;
            return;
        }
        if (leftAttributeToSend.GetComponent<CannonAttribute>().GetType() == newAttributeObj.GetComponent<CannonAttribute>().GetType())
        {
            //Attribute is already on
            return;
        }
        if (rightAttributeToSend.GetComponent<CannonAttribute>().GetType() == newAttributeObj.GetComponent<CannonAttribute>().GetType())
        {
            //Attribute is already on
            return;
        }
        else
        {
            rightAttributeToSend = newAttributeObj;
        }
    }
}
