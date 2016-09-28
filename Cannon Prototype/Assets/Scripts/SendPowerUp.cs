using UnityEngine;
using System.Collections;

public class SendPowerUp : MonoBehaviour {

	public delegate void PowerUpSend();
	public static event PowerUpSend GenericPowerUp;
	public float resetTimer = 30f;f

	private float liveTimer;

	void OnTriggerEnter(Collider other){
		if(this.GetComponent<Renderer>().enabled == true){
			if(GenericPowerUp != null)
				GenericPowerUp();
			this.GetComponent<Renderer>().enabled = false;
			StartCoroutine("redrop");
		}
	}
	//Coroutine to count down a timer without constantly calling update
	IEnumerator redrop(){
		for (liveTimer=resetTimer; liveTimer>=0; liveTimer -=Time.deltaTime){
			yield return null;
		}
		this.GetComponent<Renderer>().enabled = true;
	}	
}
