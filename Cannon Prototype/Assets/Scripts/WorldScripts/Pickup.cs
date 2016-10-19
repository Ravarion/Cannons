using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject toSend;
    public AudioClip goodSound;
    public AudioClip badSound;

    public Text powerupText;

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
        powerupText.text = toSend.GetComponent<CannonAttribute>().GetType().FullName;
    }

    void Update()
    {
        powerupText.gameObject.transform.LookAt(Camera.main.transform);
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

    void SendToCannon(GameObject cannon)
    {
        //Send attribute to main cannon
        GameObject.FindGameObjectWithTag("MainCannon").GetComponent<MainCannonAttribute>().NewAttributeToSend(toSend);

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
                PlayBadSound();
                return;
            }
        }

        //If too many pickups have been gathered by this cannon
        if (cannon.GetComponents<CannonAttribute>().Length > 3)
        {
            PlayBadSound();
            //Tell cannon to explode
        }

        //If no match is found, add the new attribute
        PlayGoodSound();
        cannon.AddComponent(toSend.GetComponent<CannonAttribute>().GetType());
    }

    void OnTriggerEnter(Collider col)
    {
        if (GetComponent<Renderer>().enabled == true)
        {
            if (col.gameObject.tag == "Cannon")
            {
                SendToCannon(col.gameObject);
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

            if(col.gameObject.tag == "Pellet")
            {
                SendToCannon(col.gameObject.GetComponent<Pellets>().cannon);
            }
        }
    }
}
