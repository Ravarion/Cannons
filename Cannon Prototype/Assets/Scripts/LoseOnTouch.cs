using UnityEngine;
using System.Collections;

public class LoseOnTouch : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cannon")
        {
            print("You lose!");
        }
    }
}
