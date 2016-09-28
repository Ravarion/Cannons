using UnityEngine;
using System.Collections;

public class WinOnTouch : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Cannon")
        {
            print("You win!");
        }
    }
}
