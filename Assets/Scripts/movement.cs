using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	GameObject[] CamerasPoints;
	public GameObject Cam;
	int counter =0;
	GameObject WormHole;

	private int moveSpeed, maxDistance;
	
	Transform target;
	GameObject initialiseParticles;
	GameObject game;
	
	public GameObject sup;
	GameObject ship2;
	OriMovement ori;
	OriPath2 pa;

	bool InstanceCheck=false;
	public bool commence = false, cool = false, moveOri = false, test = false;
	Vector3 _direction;
	
	Quaternion _look;
	Vector3 dir;
	Vector3[] dir1;
	videoSource vid;

	// Use this for initialization
	void Start () {
		pa = new OriPath2();
		dir1 = pa.Route();
		dir = dir1[1];

		game = GameObject.FindGameObjectWithTag("boid");
		WormHole = GameObject.Find("wormhole");
		CamerasPoints = GameObject.FindGameObjectsWithTag("CameraPoint");
		Cam = GameObject.FindGameObjectWithTag("MainCamera");
		ship2 = GameObject.FindGameObjectWithTag("Ori Mothership - 2");

		vid = Cam.GetComponent<videoSource>();

		counter=1;
		moveSpeed = 20;
		maxDistance =100;

		for(int i =0; i < CamerasPoints.Length; i ++){
			if(CamerasPoints[i].name == "CameraPoint")
				Cam.transform.position = CamerasPoints[i].transform.position;
			if(CamerasPoints[i].name == "CameraPoint1")
				target = CamerasPoints[i].transform;
		}
		ori = ship2.GetComponent<OriMovement>();
		Cam.transform.rotation = new Quaternion(5.7f,309.0645f, 1.4483f,0);
	}

	public bool playVid1 = false;
	// Update is called once per frame
	void Update () {
		if((WormHole!=null)&&(!InstanceCheck)){
			if (Vector3.Distance (target.position, Cam.transform.position) >= 300) {
				ParticleEmitter partials;
				partials = WormHole.GetComponent("EllipsoidParticleEmitter").particleEmitter;
				partials.emit = true;
				GameObject jump = GameObject.Find("304Start");
				game.transform.position = jump.transform.position;
				game.AddComponent<move304>();
				InstanceCheck=true;
			}
		}

		if ((Vector3.Distance (target.position, Cam.transform.position) >= maxDistance)&&(counter<2)) {
			Cam.transform.position = Vector3.MoveTowards(Cam.transform.position,target.position, moveSpeed);
			moveOri = false;
		}

		if((Vector3.Distance (target.position, Cam.transform.position) <= maxDistance)&&(counter<2)){
			cool = true;
		}

		if(counter==2){
			Cam.transform.position = target.position;
			Vector3 po = new Vector3(0,1,0);
			Cam.transform.rotation = Quaternion.AngleAxis(340,po);
			moveOri = true;
		}
		//switch the camera to the gate
		if((Vector3.Distance(ship2.transform.position,dir)<=120)&&(!test)&&(!vid.battleCommence)){
			cool = true;
			Vector3 po = new Vector3(0,1,0);
			Cam.transform.rotation = Quaternion.AngleAxis(270,po);
			test = true;
		}
		//rotate at tthe supergate
		if((test==true)&&(!vid.battleCommence)){
			Cam.transform.position = target.position;
			_direction = (ship2.transform.position - Cam.transform.position).normalized;
			_look = Quaternion.LookRotation(_direction);
			Cam.transform.rotation = Quaternion.Slerp(Cam.transform.rotation,_look,Time.deltaTime*20);
		}
		//start the vid sequence
		if((Vector3.Distance(ship2.transform.position, dir1[3]) <=12)&&(!vid.battleCommence)){
			playVid1 = true;
			test = false;
		}

		if(vid.battleCommence){

			playVid1=false;
			cool = true;
			vid.battleCommence = false;
			Cam.transform.position = target.position;
			Vector3 po = new Vector3(0,1,0);
			Cam.transform.rotation = Quaternion.AngleAxis(180,po);
			commence = true;
		}

		if(cool){
			counter+=1;
			for(int i =0; i < CamerasPoints.Length; i ++){
				if(CamerasPoints[i].name == "CameraPoint"+counter){
					target = CamerasPoints[i].transform;
					cool = false;
				}
			}
		}
	}
}
