using UnityEngine;
using System.Collections;

public class GrowWhilePressed : MonoBehaviour {

    public bool isGrowing = true;
    private float oldAxisRaw = 0f;

    void Start()
    {
        oldAxisRaw = Input.GetAxisRaw("Triggers");
    }

    void Update()
    {
        if (((Input.GetAxisRaw("Triggers") < -0.5 && Input.GetAxisRaw("Triggers") < oldAxisRaw) || Input.GetButton("Fire1")) && isGrowing)
        {
            transform.localScale *= 1.1f;
        }
        if(Input.GetAxisRaw("Triggers") > -0.1 && Input.GetAxisRaw("Triggers") > oldAxisRaw  || Input.GetButtonUp("Fire1"))
        {
            isGrowing = false;
        }
        oldAxisRaw = Input.GetAxisRaw("Triggers");
    }
}
