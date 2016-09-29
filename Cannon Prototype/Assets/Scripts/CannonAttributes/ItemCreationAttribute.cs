using UnityEngine;
using System.Collections;

public class ItemCreationAttribute : CannonAttribute {

    public override void RightTriggerDown()
    {
        GameObject newShot = Instantiate(toShoot, spawnPos.position, Quaternion.identity) as GameObject;
        newShot.GetComponent<Rigidbody>().AddForce(transform.forward * 20 * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
    }
}
