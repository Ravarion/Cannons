using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        base.Update();
        if(GetComponent<PlayerController>().currentCannon)
        {
			GetComponent<Rigidbody> ().freezeRotation = true;
            if(transform.FindChild("ShotPath").childCount > 0)
            {
                for(int i = 0; i < 15; i++)
                {
                    UpdateProjectedArc(i, i / 5f);
                }
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    CreateProjectedArc(i / 5f);
                }
            }
        }
        else
        {
            for(int i = transform.FindChild("ShotPath").childCount-1; i >= 0; i--)
            {
                Destroy(transform.FindChild("ShotPath").GetChild(i).gameObject);
            }
        }
    }

    public void CreateProjectedArc(float t)
    {
		Transform barrel = transform.FindChild ("Barrel").transform;
        Vector3 startingLoc = spawnPos.position;
		Vector2 linearVelocity = new Vector2(barrel.forward.x * 20, barrel.forward.z * 20);
        float upwardPosition = barrel.forward.y * 20f * t + 0.5f * t * t * -9.8f;
        Vector3 finalPosition = new Vector3(linearVelocity.x * t, upwardPosition, linearVelocity.y * t) + startingLoc;
        GameObject newArcObj = Instantiate(arcPrefab, finalPosition, Quaternion.identity) as GameObject;
        newArcObj.transform.parent = transform.FindChild("ShotPath");
    }

    public void UpdateProjectedArc(int i, float t)
    {
        if(i == 0)
        {
            transform.FindChild("ShotPath").GetChild(i).gameObject.SetActive(false);
        }
		Transform barrel = transform.FindChild ("Barrel").transform;
        Vector3 startingLoc = spawnPos.position;
        Vector2 linearVelocity = new Vector2(barrel.forward.x * 20, barrel.forward.z * 20);
        float upwardPosition = barrel.forward.y * 20f * t + 0.5f * t * t * -9.8f;
        Vector3 finalPosition = new Vector3(linearVelocity.x * t, upwardPosition, linearVelocity.y * t) + startingLoc;
        transform.FindChild("ShotPath").GetChild(i).position = Vector3.Lerp(transform.FindChild("ShotPath").GetChild(i).position, finalPosition, 0.2f);
    }

    //Shoot
    override public void RightTriggerDown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        PlayCannonFireSound();
        //GetComponent<Rigidbody>().AddForce(-transform.forward * blowback, ForceMode.Impulse);
        GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
        //Add attributes
        if(leftAttributeToSend != null)
        {
            //Destroy vanilla attribute if it exists
            if (newShot.GetComponent<CannonAttribute>().GetType() == typeof(CannonAttribute))
            {
                Destroy(newShot.GetComponent<CannonAttribute>());
            }
            newShot.AddComponent(leftAttributeToSend.GetComponent<CannonAttribute>().GetType());
        }
        if (rightAttributeToSend != null)
        {
            //Destroy vanilla attribute if it exists
            if (newShot.GetComponent<CannonAttribute>().GetType() == typeof(CannonAttribute))
            {
                Destroy(newShot.GetComponent<CannonAttribute>());
            }
            newShot.AddComponent(rightAttributeToSend.GetComponent<CannonAttribute>().GetType());
        }
		Transform barrel = transform.FindChild ("Barrel").transform;
        newShot.GetComponent<Rigidbody>().mass = GetComponent<Rigidbody>().mass;
        newShot.transform.localScale = transform.localScale / 2;
        newShot.GetComponent<Rigidbody>().AddForce(barrel.forward * 20 * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
        newShot.transform.rotation = barrel.rotation;
        newShot.GetComponent<MouseLook>().rotationX = GetComponent<MouseLook>().rotationX;
        newShot.GetComponent<MouseLook>().rotationY = GetComponent<MouseLook>().rotationY;
		transform.FindChild("Barrel").FindChild("Main Camera").gameObject.SetActive(false);
		//newShot.transform.FindChild("Main Camera").gameObject.SetActive(false);
        GetComponent<MouseLook>().enabled = false;
        GetComponent<PlayerController>().currentCannon = false;
    }

    public bool NewAttributeToSend(GameObject newAttributeObj)
    {
        if (leftAttributeToSend == null)
        {
            leftAttributeToSend = newAttributeObj;
            UpdateAttributeText();
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
            UpdateAttributeText();
            return true;
        }
        if (rightAttributeToSend.GetComponent<CannonAttribute>().GetType() == newAttributeObj.GetComponent<CannonAttribute>().GetType())
        {
            //Attribute is already on
            return false;
        }
        rightAttributeToSend = newAttributeObj;
        UpdateAttributeText();
        return true;
    }

    public void SwitchAttributes()
    {
        GameObject tempObject = leftAttributeToSend;
        leftAttributeToSend = rightAttributeToSend;
        rightAttributeToSend = tempObject;
        UpdateAttributeText();
    }

    public void DropAttribute()
    {
        rightAttributeToSend = null;
        UpdateAttributeText();
    }

    public override void UpdateAttributeText()
    {
        if (leftAttributeToSend == null)
        {
            attributeText.text = "Powerup Left:   Null";
        }
        else
        {
            attributeText.text = "Powerup Left:   " + leftAttributeToSend.GetComponent<CannonAttribute>().GetType().FullName;
        }
        attributeText.text += "\n";
        if (rightAttributeToSend == null)
        {
            attributeText.text += "Powerup Right: Null";
        }
        else
        {
            attributeText.text += "Powerup Right: " + rightAttributeToSend.GetComponent<CannonAttribute>().GetType().FullName;
        }
    }
}
