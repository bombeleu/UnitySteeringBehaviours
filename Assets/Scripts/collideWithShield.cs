using UnityEngine;
using System.Collections;

public class collideWithShield : MonoBehaviour {
	public GameObject collision, destroy;
	GameObject ship;
	GameObject game;
	public string attackName, attack;
	
	public bool gameExplosion = false;
	// Use this for initialization
	void Start () {
		game = this.gameObject;
		int m = Random.Range(1,4);
		ship = GameObject.Find("Ori Mothership - "+ m);
		if(gameExplosion){
			ship = GameObject.Find(attackName + " - 1");
		}else{
			ship = GameObject.Find(attackName);
		}
	}
	bool bomb = false;
	Vector3 vol;
	public bool finished = false;
	// Update is called once per frame
	void Update () {
		if(attackName==null){
			ship = GameObject.Find("Ori Mothership - 1");
		}else{
			if(gameExplosion){
				ship = GameObject.Find(attackName + " - 1");
			}else{
				ship = GameObject.Find(attackName);
			}
		}

		if(finished){
			Destroy(gameObject);
			Destroy(game);
		}

		if(ship == null)
			Destroy(gameObject);

		if(Vector3.Distance(ship.transform.position,transform.position)<=110){
			Vector3 shield = transform.position;
			GameObject shieldHit = Instantiate(collision,shield, Quaternion.identity) as GameObject;
			if(game!=null){
				transform.position = shield;
				if((gameExplosion)&&(Vector3.Distance(ship.transform.position,transform.position)<=110)){
					game = Instantiate(destroy,ship.transform.position, Quaternion.identity) as GameObject;
					finished = true;
					GameObject blowup = GameObject.Find(attackName);
					Destroy(blowup);
					Destroy(gameObject);
					Destroy(game);
				}
				Destroy(gameObject);
			}
		}else{
			transform.position = Vector3.MoveTowards(transform.position,ship.transform.position,25);
		}
	}
}