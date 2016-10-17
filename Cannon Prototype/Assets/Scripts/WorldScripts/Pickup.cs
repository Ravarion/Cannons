using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject toSend;

    void SendToCannon(GameObject cannon)
    {
        //Destroy vanilla attribute if it exists
        if (cannon.GetComponent<CannonAttribute>().GetType() == typeof(CannonAttribute))
        {
            Destroy(cannon.GetComponent<CannonAttribute>());
        }

        //Check to see if this attribute already exists on the cannon
        foreach (CannonAttribute attribute in cannon.GetComponents<CannonAttribute>())
        {
            if (attribute.GetType() == toSend.GetComponent<CannonAttribute>().GetType())
            {
                return;
            }
        }

        //If too many pickups have been gathered by this cannon
        if (cannon.GetComponents<CannonAttribute>().Length > 3)
        {
            //Tell cannon to explode
        }

        //If no match is found, add the new attribute
        cannon.AddComponent(toSend.GetComponent<CannonAttribute>().GetType());
    }

    void OnTriggerEnter(Collider col)
    {
        if (GetComponent<Renderer>().enabled == true)
        {
            if(col.gameObject.tag == "Pellet")
            {
                //Send attribute to main cannon
                GameObject.FindGameObjectWithTag("MainCannon").GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend);
                SendToCannon(col.gameObject.GetComponent<Pellets>().cannon);
            }
            if(col.gameObject.tag == "Cannon")
            {
                //Send attribute to main cannon
                GameObject.FindGameObjectWithTag("MainCannon").GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend);

                SendToCannon(col.gameObject);
            }

            if(col.gameObject.tag == "MainCannon")
            {
                col.GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend);
            }
        }
    }
}
