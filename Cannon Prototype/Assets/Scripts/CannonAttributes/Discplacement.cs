using UnityEngine;
using System.Collections;

public class Discplacement : CannonAttribute {

    public override bool ADown(bool check)
    {
        return true;
    }

    public override void ADown()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
        GameObject mCannon = GameObject.FindGameObjectWithTag("MainCannon");
        Vector3 myPos = GetComponent<Rigidbody>().transform.position;
        transform.position = mCannon.transform.position;
        mCannon.transform.position = myPos;

        //Switch cannon on
        mCannon.transform.FindChild("Main Camera").gameObject.SetActive(true);
        mCannon.GetComponent<MouseLook>().enabled = true;
        mCannon.GetComponent<PlayerController>().currentCannon = true;
        mCannon.transform.rotation = transform.rotation;
        mCannon.GetComponent<MouseLook>().rotationX = GetComponent<MouseLook>().rotationX;
        mCannon.GetComponent<MouseLook>().rotationY = GetComponent<MouseLook>().rotationY;
        //Switch previous cannon off
        GetComponent<PlayerController>().currentCannon = false;
        transform.FindChild("Main Camera").gameObject.SetActive(false);
        GetComponent<MouseLook>().enabled = false;
    }
}