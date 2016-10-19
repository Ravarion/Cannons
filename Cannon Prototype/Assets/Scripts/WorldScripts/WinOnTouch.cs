using UnityEngine;
using System.Collections;

public class WinOnTouch : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cannon" || col.gameObject.tag == " MainCannon" || col.gameObject.tag == "Pellet")
        {
            GameObject.Find("Scripts").GetComponent<Menu>().MainMenuButton();
        }
    }
}
