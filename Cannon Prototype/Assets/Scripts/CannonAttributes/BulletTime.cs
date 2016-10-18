using UnityEngine;
using System.Collections;

public class BulletTime : CannonAttribute {

    public float slowTime = 0.25f;

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        /*
        if (Input.GetKey("f"))
            Time.timeScale = slowTime;
        else
            Time.timeScale = 1.0f;
        */
	}

    public override bool ADown(bool checkOverwrite)
    {
        return true;
    }

    public override bool AHold(bool checkOverwrite)
    {
        return true;
    }

    // sets timeScale to slowTime while 'A' is held
    public override void AHold()
    {
        Time.timeScale = slowTime;
    }

    // sets timeScale back to normal time when 'A' is released
    public override void AUp()
    {
        Time.timeScale = 1.0f;
    }
}
