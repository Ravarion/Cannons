﻿using UnityEngine;
using System.Collections;

public class ItemCreationAttribute : CannonAttribute {

    public override void Start()
    {
        base.Start();
        toShoot = Resources.Load("ObjectCapsule") as GameObject;
    }

    public override bool RightTriggerDown(bool checkOverwrite)
    {
        return true;
    }

    public override void RightTriggerDown()
    {
        if(GameObject.FindGameObjectWithTag("ObjectCapsule") == null)
        {
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
