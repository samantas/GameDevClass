using UnityEngine;
using System.Collections;

public class WASDMove : MonoBehaviour {

	public float Speed;
	public float XlookSensitivity;
	public float YlookSensitivity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Movement
		if (Input.GetKey(KeyCode.W)) {
			//GetComponent<Transform>().position += fwdMove * Time.deltaTime;
			transform.position += transform.forward * Time.deltaTime * Speed;

		}

		if (Input.GetKey(KeyCode.S)) {
			//GetComponent<Transform>().position += fwdMove * Time.deltaTime;
			transform.position -= transform.forward * Time.deltaTime * Speed;
			
		}

		if (Input.GetKey(KeyCode.D)) {
			//GetComponent<Transform>().position += fwdMove * Time.deltaTime;
			transform.position += transform.right * Time.deltaTime * Speed;
			
		}

		if (Input.GetKey(KeyCode.A)) {
			//GetComponent<Transform>().position += fwdMove * Time.deltaTime;
			transform.position -= transform.right * Time.deltaTime * Speed;
			
		}

		//MouseLook
		if (Input.GetAxis ("Mouse X") > 1 || Input.GetAxis ("Mouse X") < -1) {
			transform.Rotate (transform.up, Input.GetAxis ("Mouse X") * XlookSensitivity);
		}

//		if (Input.GetAxis ("Mouse Y") > 1 || Input.GetAxis ("Mouse Y") < -1) {
//			transform.Rotate (transform.right, Input.GetAxis ("Mouse Y") * YlookSensitivity);
//		}

	}
}
