using UnityEngine;
using System.Collections;

public class TriggerManager : MonoBehaviour {

	public GameObject ball2;

	public GameObject prefab;
	public int numberOfObjects = 10;
	public float radius = 5f;
	public GameObject[] spheres;


	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider myTrigger) {
		if (myTrigger.gameObject.name == "Ball-2") {
			ball2.GetComponent<Rigidbody>().velocity = new Vector3(10,10,0);

			for (int i = 0; i < numberOfObjects; i++) {
				float angle = i * Mathf.PI * 2 / numberOfObjects;
				Vector3 pos = new Vector3(Mathf.Cos(angle), -2, Mathf.Sin(angle)) * radius;

				Instantiate(prefab, pos, Quaternion.identity);
			}
			
			spheres = GameObject.FindGameObjectsWithTag ("spheres");

		}
	}
}
