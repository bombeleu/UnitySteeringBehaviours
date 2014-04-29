using UnityEngine;
using System.Collections;

public class collideWithShield : MonoBehaviour {
	public GameObject collision;
	GameObject ship;
	GameObject game;
	// Use this for initialization
	void Start () {
		game = this.gameObject;
		ship = GameObject.Find("Ori Mothership - 1");
	}
	bool bomb = false;
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(ship.transform.position,transform.position)<110){
			Vector3 shield = new Vector3(ship.transform.position.x,ship.transform.position.y,(ship.transform.position.z-100));
			GameObject shieldHit = Instantiate(collision,shield, Quaternion.identity) as GameObject;
			if(game!=null){
				transform.position = new Vector3(transform.position.x,transform.position.y,(ship.transform.position.z-100));
				Destroy(game);
			}
		}else{
			transform.position = Vector3.MoveTowards(transform.position,ship.transform.position,25);
		}
	}
}
