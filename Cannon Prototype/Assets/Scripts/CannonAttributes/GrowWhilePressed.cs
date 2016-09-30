using UnityEngine;
using System.Collections;

public class GrowWhilePressed : MonoBehaviour {

    public bool isGrowing = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && isGrowing)
        {
            transform.localScale *= 1.1f;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isGrowing = false;
        }
    }
}
