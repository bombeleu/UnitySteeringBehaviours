using UnityEngine;
using System.Collections;

public class spawnGauold : MonoBehaviour {
	public bool bringForth = false;
	public GameObject gauld,gauld1,gauld2,gauld3, targ, WormHole;
	movement move;
	Vector3 spawn,spawn1,spawn2;
	bool check = false;
	// Use this for initialization
	void Start () {
		spawn = targ.transform.position;
		spawn1 = new Vector3(targ.transform.position.x-410.155f,targ.transform.position.y,targ.transform.position.z);
		spawn2 = new Vector3(targ.transform.position.x+410.155f,targ.transform.position.y,targ.transform.position.z);
		move = gameObject.GetComponent<movement>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if((bringForth)&&(!check)){
			if(check){
				ParticleEmitter partials;
				partials = WormHole.GetComponent("EllipsoidParticleEmitter").particleEmitter;
				partials.emit = true;
			}
			gauld1 = Instantiate(gauld,spawn,Quaternion.identity) as GameObject;
			gauld1.name = "Hatak - 8";
			gauld2 = Instantiate(gauld,spawn1,Quaternion.identity) as GameObject;
			gauld2.name = "Hatak - 9";
			gauld3 = Instantiate(gauld,spawn2,Quaternion.identity) as GameObject;
			gauld3.name = "Hatak - 10";
			check = true;
		}
	}
}
