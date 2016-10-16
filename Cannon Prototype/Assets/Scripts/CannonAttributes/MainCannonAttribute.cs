using UnityEngine;
using System.Collections;

public class MainCannonAttribute : CannonAttribute {

    public GameObject arcPrefab;
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

    override public void Update()
    {
        for(int i = transform.FindChild("ShotPath").childCount-1; i >= 0; i--)
        {
            Destroy(transform.FindChild("ShotPath").GetChild(i).gameObject);
        }
        for(int i = 0; i < 5; i++)
        {
            CreateProjectedArc(i/5f);
        }
    }

    public void CreateProjectedArc(float t)
    {
        Vector3 startingLoc = spawnPos.position;
        Vector2 linearVelocity = new Vector2(transform.forward.x * 20, transform.forward.z * 20);
        float upwardPosition = transform.forward.y * 20f * t + 0.5f * t * t * -9.8f;
        Vector3 finalPosition = new Vector3(linearVelocity.x * t, upwardPosition, linearVelocity.y * t);
        GameObject newArcObj = Instantiate(arcPrefab, startingLoc + finalPosition, Quaternion.identity) as GameObject;
        newArcObj.transform.parent = transform.FindChild("ShotPath");
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
        PlayCannonFireSound();
        GetComponent<Rigidbody>().AddForce(-transform.forward * blowback, ForceMode.Impulse);
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

    public bool NewAttributeToSend(GameObject newAttributeObj)
    {
        if (leftAttributeToSend == null)
        {
            leftAttributeToSend = newAttributeObj;
            return true;
        }
        if (leftAttributeToSend.GetComponent<CannonAttribute>().GetType() == newAttributeObj.GetComponent<CannonAttribute>().GetType())
        {
            //Attribute is already on
            return false;
        }
        if (rightAttributeToSend == null)
        {
            rightAttributeToSend = newAttributeObj;
            return true;
        }
        if (rightAttributeToSend.GetComponent<CannonAttribute>().GetType() == newAttributeObj.GetComponent<CannonAttribute>().GetType())
        {
            //Attribute is already on
            return false;
        }
        rightAttributeToSend = newAttributeObj;
        return true;
    }

    public void SwitchAttributes()
    {
        GameObject tempObject = leftAttributeToSend;
        leftAttributeToSend = rightAttributeToSend;
        rightAttributeToSend = tempObject;
    }

    public void DropAttribute()
    {
        rightAttributeToSend = null;
    }
}
