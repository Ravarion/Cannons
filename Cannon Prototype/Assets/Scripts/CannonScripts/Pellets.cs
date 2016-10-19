using UnityEngine;
using System.Collections;



public class Pellets : MonoBehaviour {

    public GameObject cannon;
    private float lifeTime = 0.0f;
    public float lifeTimeEnd = 5.0f;
	
	// Update is called once per frame
	void Update ()
    {
        lifeTime += Time.deltaTime;

        //if the pellet dosn't collide with anything for 5 seconds it is destroyed
        if (lifeTime > lifeTimeEnd)
            Destroy(gameObject);
	}

    //Destroys pellet when it collides with anything except the cannon
    /*void OnCollisionEnter(Collision col)
    {  
        if(col.gameObject.tag != "Cannon")
        {
            Destroy(gameObject);
        }
    }*/
}
