using UnityEngine;
using System.Collections;

public class ItemCreationAttribute : CannonAttribute {

    public float blowback;

    public override void RightTriggerDown()
    {
        if(GameObject.FindGameObjectWithTag("ObjectCapsule") == null)
        {
            blowback = -25;
            GetComponent<Rigidbody>().AddForce(transform.forward * blowback);
            foreach (GameObject spawnedObject in GameObject.FindGameObjectsWithTag("SpawnedObject"))
            {
                if(spawnedObject.GetComponent<GrowWhilePressed>().isGrowing)
                {
                    return;
                }
            }
            GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
            newShot.GetComponent<Rigidbody>().AddForce(transform.forward * 20 * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
        }
    }
}
