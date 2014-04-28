using UnityEngine;
using System.Collections;

public class collideWithShield : MonoBehaviour {
	public GameObject collision;
	GameObject ship;
	// Use this for initialization
	void Start () {
		ship = GameObject.Find("Ori Mothership - 1");
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(ship.transform.position,transform.position)<150){
			Vector3 shield = transform.position;
			Destroy(this.gameObject);
			GameObject shieldHit = Instantiate(collision,shield, Quaternion.identity) as GameObject;
		}
	
	}

}
