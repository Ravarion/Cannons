using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Color pickupGetColor = Color.blue;
	public Color originalColor = Color.gray;
	public bool currentCannon = true;
    public bool isGrounded = false;
    private bool m_isAxisInUse = false;

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
        foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
        {
            if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
            {
                attribute.RightStickMovement(Input.GetAxis("Right_Stick_X"), Input.GetAxis("Right_Stick_Y"));
                break;
            }
            if (attribute.RightStickMovement(true))
            {
                attribute.RightStickMovement(Input.GetAxis("Right_Stick_X"), Input.GetAxis("Right_Stick_Y"));
                break;
            }
        }

        /*if (Input.GetButtonDown("Fire1"))
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
        }*/
        if (Input.GetAxisRaw("Triggers") < 0 || Input.GetButtonDown("Fire1"))
        {
            if (m_isAxisInUse == false)
            {
                foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
                {
                    if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
                    {
                        attribute.RightTriggerDown();
                        m_isAxisInUse = true;
                        break;
                    }
                    if (attribute.RightTriggerDown(true))
                    {
                        attribute.RightTriggerDown();
                        break;
                    }
                }
            }
        }
        if (Input.GetAxisRaw("Triggers") == 0)
        {
            m_isAxisInUse = false;
        }
        if (Input.GetButton("Right_Bumper"))
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
        if (Input.GetAxisRaw("DPad_X") < 0)
        {
            GetComponent<CannonAttribute>().DPadMovement(-1, 0);
        }
        if (Input.GetAxisRaw("DPad_X") > 0)
        {
            GetComponent<CannonAttribute>().DPadMovement(1, 0);
        }
    }

    void OnCollisionStay(Collision col)
    {
        //Todo: Update grounded
    }

    //when this object is created, it is subscribed to the event GenericPowerUpAbility
    void OnEnable(){
        //JetpackPickUp.JetPackOn += GenericPowerUpAbility;
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