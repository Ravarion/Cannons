using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject toSend;
    public AudioClip goodSound;
    public AudioClip badSound;

    void Start()
    {
        if(!goodSound)
        {
            goodSound = Resources.Load("Sounds/pickup") as AudioClip;
        }
        if (!badSound)
        {
            badSound = Resources.Load("Sounds/badResult") as AudioClip;
        }
    }

    void PlayGoodSound()
    {
        if (goodSound)
        {
            GetComponent<AudioSource>().clip = goodSound;
            GetComponent<AudioSource>().Play();
        }
    }

    void PlayBadSound()
    {
        if (badSound)
        {
            GetComponent<AudioSource>().clip = badSound;
            GetComponent<AudioSource>().Play();
        }
    }

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
                        PlayBadSound();
                        return;
                    }
                }

                //If too many pickups have been gathered by this cannon
                if (col.gameObject.GetComponents<CannonAttribute>().Length > 3)
                {
                    PlayBadSound();
                    //Tell cannon to explode
                }

                //If no match is found, add the new attribute
                PlayGoodSound();
                col.gameObject.AddComponent(toSend.GetComponent<CannonAttribute>().GetType());
            }

            if(col.gameObject.tag == "MainCannon")
            {
                if(col.GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend))
                {
                    PlayGoodSound();
                }
                else
                {
                    PlayBadSound();
                }
            }
        }
    }
}
