using UnityEngine;
using System.Collections;

public class gauoldAttack : MonoBehaviour {
	public GameObject fireRound,fireRound1,fireRound2,fire,rounds2,cam;
	movement move;
	moveGauold positions;
	int oldcount = 0;
	// Use this for initialization
	void Start () {
		positions = gameObject.GetComponent<moveGauold>();
		cam = GameObject.Find("Main Camera");
		move = cam.GetComponent<movement>();
	}

	collideWithShield collide;
	// Update is called once per frame
	void Update () {
		if(move.counter >=12){
			if((oldcount == 0)||(positions.co > oldcount)){
				rounds2= Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
				addTarget();
				rounds2= Instantiate(fire,fireRound1.transform.position, Quaternion.identity) as GameObject;
				addTarget();
				rounds2= Instantiate(fire,fireRound2.transform.position, Quaternion.identity) as GameObject;
				addTarget();
			}else if(rounds2!=null){
				if(Vector3.Distance(rounds2.transform.position,transform.position)>800){
					rounds2= Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
					addTarget();
					rounds2= Instantiate(fire,fireRound1.transform.position, Quaternion.identity) as GameObject;
					addTarget();
					rounds2= Instantiate(fire,fireRound2.transform.position, Quaternion.identity) as GameObject;
					addTarget();
				}
				if(Vector3.Distance(rounds2.transform.position,transform.position)>1400){
					rounds2= Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
					addTarget();
					rounds2= Instantiate(fire,fireRound1.transform.position, Quaternion.identity) as GameObject;
					addTarget();
					rounds2= Instantiate(fire,fireRound2.transform.position, Quaternion.identity) as GameObject;
					addTarget();
				}
			}
			oldcount++;

		}
		if(rounds2==null){
			oldcount = 0;
		}

	}

	void addTarget(){
		collide = rounds2.GetComponent<collideWithShield>();
		collide.attackName = positions.attackName;
	}
}
