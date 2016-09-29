using UnityEngine;
using System.Collections;

public class SpawnObjectOnPress : MonoBehaviour {

    public GameObject toSpawn;

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
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
