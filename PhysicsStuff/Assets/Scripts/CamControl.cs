using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

	public GameObject[] cams;
	private int currentCam = 0;

	// Use this for initialization
	void Start () {

		ActivateCam (currentCam);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			currentCam += 1;

			if(currentCam == cams.Length){
				currentCam = 0;
			}

			ActivateCam (currentCam);
		}

		}

	public void DeactivateAllCams(){
		for (int i = 0; i < cams.Length; i++) {
			//equivalent of something.enabled = false; for components but for game objects! 
			cams[i].SetActive (false);
		}
	}

	public void ActivateCam(int camIndex){

		DeactivateAllCams ();
		//activate camindex cam
		cams [camIndex].SetActive (true);
	}
		
}