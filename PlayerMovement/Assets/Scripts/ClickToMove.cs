using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Ground"){

				//Option 1
				//transform.position = Vector3.Lerp (transform.position, hit.point, 0.2f);

				//Option 2
				//vector between destination and current location
				Vector3 move;
				move = hit.point - transform.position;
				move.Normalize ();

				transform.position += move * Time.deltaTime * moveSpeed;

			}

		}

	}
}
