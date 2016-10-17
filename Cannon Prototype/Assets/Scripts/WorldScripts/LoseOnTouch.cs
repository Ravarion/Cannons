using UnityEngine;
using System.Collections;

public class LoseOnTouch : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MainCannon")
        {
            GameObject.Find("Scripts").GetComponent<LevelManager>().ResetLevel();
        }
        if(col.gameObject.tag == "Cannon")
        {
            col.gameObject.GetComponent<CannonAttribute>().SelfDestruct();
        }
    }
}
