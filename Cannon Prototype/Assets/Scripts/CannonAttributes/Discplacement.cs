using UnityEngine;
using System.Collections;

public class Discplacement : CannonAttribute {

    public override void ADown()
    {
        if(GetComponent<PlayerController>().mainCannon == false)
        {
            foreach (GameObject cannon in GameObject.FindGameObjectsWithTag("Cannon"))
            {
                GameObject mCannon = cannon;
                Vector3 myPos = GetComponent<Rigidbody>().transform.position;
                GetComponent<Rigidbody>().transform.position = mCannon.transform.position;
                mCannon.transform.position = myPos;

                //Switch cannon on
                mCannon.transform.FindChild("Main Camera").gameObject.SetActive(true);
                mCannon.GetComponent<MouseLook>().enabled = true;
                mCannon.GetComponent<PlayerController>().currentCannon = true;
                //Switch previous cannon off
                GetComponent<PlayerController>().currentCannon = false;
                transform.FindChild("Main Camera").gameObject.SetActive(false);
                GetComponent<Rigidbody>().freezeRotation = true;
                GetComponent<MouseLook>().enabled = false;
            }
            GetComponent<PlayerController>().mainCannon = true;
        }
    }
}
/*if (cannon.GetComponent<PlayerController>().mainCannon)
                {
                }*/