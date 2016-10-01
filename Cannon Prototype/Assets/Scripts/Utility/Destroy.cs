using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    
    public float destructionTimer = 0;
    public GameObject toDestroy;
	
    void Start()
    {
        if(toDestroy == null)
        {
            toDestroy = gameObject;
        }
    }

	void Update () {
	    if(destructionTimer > 0)
        {
            destructionTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(toDestroy);
        }
	}
}
