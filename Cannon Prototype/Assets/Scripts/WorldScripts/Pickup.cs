using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject toSend;

    void OnTriggerEnter(Collider col)
    {
        if (GetComponent<Renderer>().enabled == true)
        {
            if(col.gameObject.tag == "Cannon")
            {
                //Send attribute to main cannon
                GameObject.FindGameObjectWithTag("MainCannon").GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend);

                //Destroy vanilla attribute if it exists
                if (col.gameObject.GetComponent<CannonAttribute>().GetType() == typeof(CannonAttribute))
                {
                    Destroy(col.gameObject.GetComponent<CannonAttribute>());
                }

                //Check to see if this attribute already exists on the cannon
                foreach (CannonAttribute attribute in col.gameObject.GetComponents<CannonAttribute>())
                {
                    if (attribute.GetType() == toSend.GetComponent<CannonAttribute>().GetType())
                    {
                        return;
                    }
                }

                //If too many pickups have been gathered by this cannon
                if (col.gameObject.GetComponents<CannonAttribute>().Length > 3)
                {
                    //Tell cannon to explode
                }

                //If no match is found, add the new attribute
                col.gameObject.AddComponent(toSend.GetComponent<CannonAttribute>().GetType());
            }

            if(col.gameObject.tag == "MainCannon")
            {
                col.GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend);
            }
        }
    }
}
