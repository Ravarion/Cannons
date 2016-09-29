using UnityEngine;
using System.Collections;

public class GetPickups : MonoBehaviour {
	public Color pickupGetColor = Color.blue;
	public Color originalColor = Color.gray;

	//when this object is created, it is subscribed to the event GenericPowerUpAbility
	void OnEnable(){
		SendPowerUp.GenericPowerUp += GenericPowerUpAbility;
	}
	//when the event GenericPowerUpAbility occurs, change color to pickupGetColor
	void GenericPowerUpAbility(){
		this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", pickupGetColor);
	}

	//drop
	void Update(){
		if (Input.GetKey(KeyCode.F)){
			this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", originalColor);
        }
	}
}