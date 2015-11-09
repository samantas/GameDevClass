using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

	public GameObject[] cams;
	private int currentCam = 0;

	public GameObject firstDomino;
	public AudioClip nyc;
	public AudioSource backgroundMusic;

	private bool isPlaying = false;
	private bool hasPressed = false;

	// Use this for initialization
	void Start () {

		//this doesn't seem to be working properly, on start, the active cam is 1 not 0 in the array
		currentCam = 0;
		ActivateCam (currentCam);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.C)) {
			currentCam += 1;

			if(currentCam == cams.Length){
				currentCam = 0;
			}

			ActivateCam (currentCam);
		}

		// if user presses space bar, start audio and game.
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space Pressed");
			firstDomino.transform.Rotate (Time.deltaTime, 0, 50);
			firstDomino.transform.Rotate (0,Time.deltaTime,0,Space.World);

			if (!isPlaying && !hasPressed) {
			isPlaying = true;
			hasPressed = true;
			backgroundMusic.clip = nyc;
			backgroundMusic.Play();
			} 

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