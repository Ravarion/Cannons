using UnityEngine;
using System.Collections;

public class Pellets : MonoBehaviour {

    public GameObject cannon;

	// Use this for initialization
	void Start () {

        cannon = GameObject.Find("SubCannon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Jetpack Pickup")
        {
            cannon.AddComponent<Jetpack>();
        }
    }

    void OnCollisionEnter(Collision col)
    {  
        if(col.gameObject.name != "Cannon" & col.gameObject.name != "Jetpack Pickup")
        {
            Destroy(gameObject);
        }
    }
}
