using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Color pickupGetColor = Color.blue;
	public Color originalColor = Color.gray;
	public bool currentCannon = true;
    public bool mainCannon = false;

	//when this object is created, it is subscribed to the event GenericPowerUpAbility
	void OnEnable(){
        JetpackPickUp.JetPackOn += GenericPowerUpAbility;
	}
	//when the event GenericPowerUpAbility occurs, change color to pickupGetColor
	void GenericPowerUpAbility(){
		this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", pickupGetColor);
        this.gameObject.GetComponent<Jetpack>().enabled=true;
	}

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Cannon").Length < 2)
        {
            mainCannon = true;
        }
        else
        {
            mainCannon = false;
        }
    }

	void Update(){
		if (Input.GetKey(KeyCode.F)){
            ResetPowerUp();
        }
	}

    //this is called to disable current powerups, intended to be simplified with enums
    void ResetPowerUp(){
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", originalColor);

        //if the jetpack script is enabled, disable it
        if (this.gameObject.GetComponent<Jetpack>().enabled)
            this.gameObject.GetComponent<Jetpack>().enabled=false;
    }
}