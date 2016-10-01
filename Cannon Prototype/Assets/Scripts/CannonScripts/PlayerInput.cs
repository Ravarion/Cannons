using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    void Update()
    {
        foreach (CannonAttribute attribute in GetComponents<CannonAttribute>())
        {
            if(attribute == GetComponents<CannonAttribute>()[GetComponents<CannonAttribute>().Length-1])
            {
                attribute.LeftStickMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                break;
            }
            if(attribute.LeftStickMovement(true))
            {
                attribute.LeftStickMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            foreach(CannonAttribute attribute in GetComponents<CannonAttribute>())
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
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<CannonAttribute>().AHold();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<CannonAttribute>().DPadMovement(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<CannonAttribute>().DPadMovement(1, 0);
        }
    }
}
