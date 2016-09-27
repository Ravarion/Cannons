using UnityEngine;
using System.Collections;

public class StickyAttribute : MonoBehaviour {



	void OnCollisionEnter(Collision col)
    {
        print("Enter");
    }

    void OnCollisionStay(Collision col)
    {
        print("Stay");
    }

    void OnCollisionExit(Collision col)
    {
        print("Exit");
    }
}
