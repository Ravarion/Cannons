using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Color pickupGetColor = Color.blue;
	public Color originalColor = Color.gray;
	public bool currentCannon = true;
    public bool isGrounded = false;
    private bool TriggersInUse = false;
    private bool XDPadInUse = false;
    private bool YDPadInUse = false;

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

        
        if (Input.GetAxisRaw("Triggers") < -0.5 || Input.GetButtonDown("Fire1")) //Right Trigger
        {
            if (TriggersInUse == false)
            {
                foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
                {
                    if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
                    {
                        TriggersInUse = true;
                        attribute.RightTriggerDown();
                        break;
                    }
                    if (attribute.RightTriggerDown(true))
                    {
                        TriggersInUse = true;
                        attribute.RightTriggerDown();
                        break;
                    }
                }
            }
        }
        if (Input.GetAxisRaw("Triggers") > 0.5) //Left Trigger
        {
            print("Left Trigger!");
        }
        if (Input.GetAxisRaw("Triggers") > -0.5 && Input.GetAxisRaw("Triggers") < 0.5)
        {
            TriggersInUse = false;
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
<<<<<<< HEAD
        if (Input.GetAxisRaw("DPad_X") < 0)
=======
        if (Input.GetButtonDown("Left_Bumper"))
        {
            print("Left Bumper!");
        }

        if (Input.GetAxisRaw("DPad_X") < -0.5 && XDPadInUse == false)
>>>>>>> 14702db18b252bbda1b9e7f9a26846e00dc68fc9
        {
            XDPadInUse = true;
            GetComponent<CannonAttribute>().DPadMovement(-1, 0);
        }
        if (Input.GetAxisRaw("DPad_X") > 0.5 && XDPadInUse == false)
        {
            XDPadInUse = true;
            GetComponent<CannonAttribute>().DPadMovement(1, 0);
        }
<<<<<<< HEAD
=======
        if (Input.GetAxisRaw("DPad_X") > -0.5 && Input.GetAxisRaw("DPad_X") < 0.5)
        {
            XDPadInUse = false;
        }

        if (Input.GetAxisRaw("DPad_Y") < -0.5 && YDPadInUse == false)
        {
            YDPadInUse = true;
        }
        if (Input.GetAxisRaw("DPad_Y") > 0.5 && YDPadInUse == false)
        {
            YDPadInUse = true;
        }
        if (Input.GetAxisRaw("DPad_Y") > -0.5 && Input.GetAxisRaw("DPad_Y") < 0.5)
        {
            YDPadInUse = false;
        }

        if(Input.GetButtonDown("A"))
        {
            print("A");
        }
        if (Input.GetButtonDown("B"))
        {
            print("B");
        }
        if (Input.GetButtonDown("X"))
        {
            print("X");
        }
        if (Input.GetButtonDown("Y"))
        {
            print("Y");
        }

        if (Input.GetButtonDown("Start"))
        {
            print("Start");
        }
        if (Input.GetButtonDown("Back"))
        {
            print("Back");
        }

        if (Input.GetButtonDown("Left_Stick_Click"))
        {
            print("Left Stick Click");
        }
        if (Input.GetButtonDown("Right_Stick_Click"))
        {
            print("Right Stick Click");
        }
>>>>>>> 14702db18b252bbda1b9e7f9a26846e00dc68fc9
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