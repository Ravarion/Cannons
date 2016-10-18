using UnityEngine;
using System.Collections;

public class BulletTime : CannonAttribute {

    public float slowTime = 0.25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        /*
        if (Input.GetKey("f"))
            Time.timeScale = slowTime;
        else
            Time.timeScale = 1.0f;
        */
	}

    // sets timeScale to slowTime while 'A' is held
    public override void AHold()
    {
        Time.timeScale = slowTime;
        base.AHold();
    }

    // sets timeScale back to normal time when 'A' is released
    public override void AUp()
    {
        Time.timeScale = 1.0f;
        base.AUp();
    }
}
