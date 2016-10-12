using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    void Update()
    {
        //Leftstick Movement
        GetComponent<CannonAttribute>().LeftStickMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
        {
            foreach(CannonAttribute attribute in GetComponents<CannonAttribute>())
            {
                attribute.RightTriggerDown();
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CannonAttribute>().AUp();
        }
    }
}
