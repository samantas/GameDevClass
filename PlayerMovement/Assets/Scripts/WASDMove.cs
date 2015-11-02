using UnityEngine;
using System.Collections;

public class WASDMove : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

	}
}
