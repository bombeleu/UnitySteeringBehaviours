using UnityEngine;
using System.Collections;

public class move304 : MonoBehaviour {

	GameObject obj,target;

	// Use this for initialization
	void Start () {

		target = GameObject.Find("304Start1");

		obj = GameObject.FindGameObjectWithTag("boid");


	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(obj.transform.position,target.transform.position)>=1)
			obj.transform.position = Vector3.MoveTowards(obj.transform.position,target.transform.position,100);
	}
}
