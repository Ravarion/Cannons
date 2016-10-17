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
        if(!currentCannon)
        {
            return;
        }

        /**Left Stick*/
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
        /**Right Stick*/
        foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
        {
            if (attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length - 1])
            {
                attribute.RightStickMovement(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                break;
            }
            if (attribute.RightStickMovement(true))
            {
                attribute.RightStickMovement(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                break;
            }
        }

        /*Right Trigger*/
        if (Input.GetAxisRaw("Triggers") < -0.5 || Input.GetButtonDown("Fire1"))
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
        /*Left Trigger*/
        if (Input.GetAxisRaw("Triggers") > 0.5)
        {
            print("Left Trigger!");
        }
        if (Input.GetAxisRaw("Triggers") > -0.5 && Input.GetAxisRaw("Triggers") < 0.5)
        {
            TriggersInUse = false;
        }

        if (Input.GetButton("Left_Bumper") || Input.GetKey(KeyCode.Space))
        {
            GetComponents<CannonAttribute>()[0].AHold();
        }
        if (Input.GetButtonDown("Left_Bumper") || Input.GetKeyDown(KeyCode.Space))
        {
            GetComponents<CannonAttribute>()[0].ADown();
        }
        if (Input.GetButton("Right_Bumper"))
        {
            if (GetComponents<CannonAttribute>().Length > 1)
            {
                GetComponents<CannonAttribute>()[1].AHold();
            }
        }
        if (Input.GetButtonDown("Right_Bumper"))
        {
            if(GetComponents<CannonAttribute>().Length > 1)
            {
                GetComponents<CannonAttribute>()[1].ADown();
            }
        }
        if (Input.GetButton("A"))
        {
            if (GetComponents<CannonAttribute>().Length > 2)
            {
                GetComponents<CannonAttribute>()[2].AHold();
            }
        }
        if (Input.GetButtonDown("A"))
        {
            if (GetComponents<CannonAttribute>().Length > 2)
            {
                GetComponents<CannonAttribute>()[2].ADown();
            }
        }

        /** DPAD */
        if (Input.GetAxisRaw("DPad_X") < -0.5 && XDPadInUse == false)
        {
            XDPadInUse = true;
            GetComponent<CannonAttribute>().DPadMovement(-1, 0);
        }
        if (Input.GetAxisRaw("DPad_X") > 0.5 && XDPadInUse == false)
        {
            XDPadInUse = true;
            GetComponent<CannonAttribute>().DPadMovement(1, 0);
        }
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
        /** END DPAD */

        if (Input.GetButtonDown("B") || Input.GetKeyDown(KeyCode.X))
        {
            if(GetComponent<MainCannonAttribute>())
            {
                GetComponent<MainCannonAttribute>().SwitchAttributes();
            }
        }
        if (Input.GetButtonDown("X") || Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<CannonAttribute>().SwitchTo(GameObject.FindGameObjectWithTag("MainCannon"));
        }
        if (Input.GetButtonDown("Y") || Input.GetKeyDown(KeyCode.C))
        {
            if (GetComponent<MainCannonAttribute>())
            {
                GetComponent<MainCannonAttribute>().DropAttribute();
            }
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
    }

    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
        GetComponent<Rigidbody>().drag = 1;
        //Todo: Improved isGrounded logic
    }

    void OnCollisionExit(Collision col)
    {
        isGrounded = false;
        GetComponent<Rigidbody>().drag = 0;
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