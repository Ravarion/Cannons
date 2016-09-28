using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<CannonAttribute>().LeftStickMovement(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<CannonAttribute>().LeftStickMovement(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<CannonAttribute>().LeftStickMovement(1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<CannonAttribute>().LeftStickMovement(-1, 0);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<CannonAttribute>().AHold();
        }
    }
}
