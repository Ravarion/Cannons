using UnityEngine;
using System.Collections;

public class GrapplingHook : CannonAttribute {

	// Use this for initialization
	public override void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
	
	}

    public override bool AHold(bool checkOverwrite)
    {
        return true;
    }

    public override void AHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }
    }
}
