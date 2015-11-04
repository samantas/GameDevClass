using UnityEngine;
using System.Collections;

public class CamTrigger : MonoBehaviour {

	public CamControl camControl;
	public GameObject camToActivate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider myTrigger){
		
		Debug.Log ("Trigger hit!");

		camControl.DeactivateAllCams ();

		//activate camToActivate
		camToActivate.SetActive (true);

	}
}
