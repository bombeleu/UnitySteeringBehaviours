using UnityEngine;
using System.Collections;

public class oriAttack : MonoBehaviour {
	public GameObject fireRound,target,fire,rounds2,cam,pos1,pos2;
	movement move;
	moveGauold positions;
	bool tar = false, story = false;
	collideWithShield collide;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
		move = cam.GetComponent<movement>();
		pos1= GameObject.Find("CameraPoint8");
		pos2 = GameObject.Find ("Hatak - 5.2");
	}

	// Update is called once per frame
	void Update () {
		if((move.counter >=8)&&(pos1!=null)){
			if(Vector3.Distance(cam.transform.position,pos1.transform.position)<100){
				if(!tar){
					rounds2 = Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
					rounds2.name = "OriBeam";
					addTarget(rounds2, target.name);
					tar = true;
				}
			}
		}
		if((move.counter >=12)&&(pos2!=null)){
			if((gameObject.name =="Ori Mothership - 1")&&(!story)){
				positions = pos2.GetComponent<moveGauold>();
				if(Vector3.Distance(pos2.transform.position,positions.path[positions.path.Length-1])<=100){
					rounds2 = Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
					rounds2.name = "OriBeam";
					addTarget(rounds2, pos2.name);
					story = true;
				}
			}
		}
	
	}
	
	void addTarget(GameObject addition,string attack){
		collide = addition.GetComponent<collideWithShield>();
		collide.attackName = attack;
		if((attack!="304aktuell - Kopie - 1")&&(attack!="304aktuell - Kopie - 2"))
			collide.gameExplosion =  true;
	}
}
