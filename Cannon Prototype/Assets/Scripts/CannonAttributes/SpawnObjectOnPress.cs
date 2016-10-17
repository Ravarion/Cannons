using UnityEngine;
using System.Collections;

public class SpawnObjectOnPress : MonoBehaviour {

    public GameObject toSpawn;

	void Update ()
    {
        if (Input.GetAxisRaw("Triggers") < -0.5 || Input.GetButtonDown("Fire1"))
        {
            GameObject spawned = Instantiate(toSpawn, transform.position, Quaternion.identity) as GameObject;
            foreach(GameObject cannon in GameObject.FindGameObjectsWithTag("Cannon"))
            {
                if(cannon.GetComponent<PlayerController>().currentCannon)
                {
                    spawned.transform.LookAt(cannon.transform);
                }
            }
            Destroy(gameObject);
        }
    }
}
