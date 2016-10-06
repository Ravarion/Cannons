using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Color pickupGetColor = Color.blue;
	public Color originalColor = Color.gray;
	public bool currentCannon = true;
    public bool isGrounded = false;

    void Update()
    {
        foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
        {
            if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
            {
                attribute.LeftStickMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                break;
            }
            if (attribute.LeftStickMovement(true))
            {
                attribute.LeftStickMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
            {
                if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
                {
                    attribute.RightTriggerDown();
                    break;
                }
                if (attribute.RightTriggerDown(true))
                {
                    attribute.RightTriggerDown();
                    break;
                }
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
            {
                if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
                {
                    attribute.AHold();
                    break;
                }
                if (attribute.AHold(true))
                {
                    attribute.AHold();
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<CannonAttribute>().DPadMovement(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<CannonAttribute>().DPadMovement(1, 0);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<CannonAttribute>().SwitchTo(GameObject.FindGameObjectWithTag("MainCannon"));
        }
    }

    void OnCollisionStay(Collision col)
    {
        //Todo: Update grounded
    }

	//when the event GenericPowerUpAbility occurs, change color to pickupGetColor
	void GenericPowerUpAbility(){
		this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", pickupGetColor);
        this.gameObject.GetComponent<Jetpack>().enabled=true;
	}

    //this is called to disable current powerups, intended to be simplified with enums
    void ResetPowerUp(){
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", originalColor);

        //if the jetpack script is enabled, disable it
        if (this.gameObject.GetComponent<Jetpack>().enabled)
            this.gameObject.GetComponent<Jetpack>().enabled=false;
    }
}