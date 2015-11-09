using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractiveText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		string updateText = "";

		GetComponent<Text> ().text = updateText;

	}
}
