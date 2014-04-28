using UnityEngine;
using System.Collections;

public class collided : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider shipInRange)
	{
		Debug.Log(shipInRange.gameObject.tag);
	
	}
	void OnTriggerExit (Collider playerNotInRange)
	{
	
		Debug.Log ("Here now");
	
	}
}
