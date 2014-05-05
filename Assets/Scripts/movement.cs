using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	GameObject[] CamerasPoints;
	public GameObject Cam;
	public int counter =0;
	GameObject WormHole,ship2, lookVector,initialiseParticles,game,downTheHatchet,removedShip;

	moveGauold reachDestination;
	private int moveSpeed, maxDistance;
	Transform target;
	OriMovement ori;
	OriPath2 pa;
	bool InstanceCheck=false,port = false,cameraOneil = false;
	public bool commence = false, changeCameraAngle = false, moveOri = false, test = false,
	playVid1 = false,movecam304 = false,longRange = false,moveShip7 = false,moveShip5 = false;
	spawnGauold spawn;
	Vector3 _direction,dir,dople;
	
	Quaternion _look;
	Vector3[] dir1;
	videoSource vid;

	Attack304 attack;
	Quaternion targets;

	// Use this for initialization
	void Start () {
		pa = new OriPath2();
		dir1 = pa.Route();
		dir = dir1[1];

		game = GameObject.FindGameObjectWithTag("Earth ship1");
		WormHole = GameObject.Find("wormhole-1");
		CamerasPoints = GameObject.FindGameObjectsWithTag("CameraPoint");
		Cam = GameObject.FindGameObjectWithTag("MainCamera");
		ship2 = GameObject.FindGameObjectWithTag("Ori Mothership - 2");

		vid = Cam.GetComponent<videoSource>();

		dople = new Vector3(280,190,80);
		counter=1;
		moveSpeed = 20;
		maxDistance =100;

		downTheHatchet = GameObject.FindGameObjectWithTag("Hatak 1");
		reachDestination = downTheHatchet.GetComponent<moveGauold>();

		for(int i =0; i < CamerasPoints.Length; i ++){
			if(CamerasPoints[i].name == "CameraPoint")
				Cam.transform.position = CamerasPoints[i].transform.position;
			if(CamerasPoints[i].name == "CameraPoint1")
				target = CamerasPoints[i].transform;
		}
		ori = ship2.GetComponent<OriMovement>();
		attack = game.GetComponent<Attack304>();
		Cam.transform.rotation = new Quaternion(5.7f,309.0645f, 1.4483f,0);
		targets = new Quaternion(0.1f, -0.5f, 0.0f, 0.9f);
		removedShip = GameObject.Find("Hatak - 5.2");
	}

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
			changeCameraAngle = true;
		}

		if(counter==2){
			Cam.transform.position = target.position;
			Vector3 po = new Vector3(0,1,0);
			Cam.transform.rotation = Quaternion.AngleAxis(340,po);
			moveOri = true;
		}

		//switch the camera to the gate
		if((Vector3.Distance(ship2.transform.position,dir)<=120)&&(!test)&&(!vid.battleCommence)&&(!attack.move304camera)){
			changeCameraAngle = true;
			Vector3 po = new Vector3(0,1,0);
			Cam.transform.rotation = Quaternion.AngleAxis(270,po);
			test = true;
		}

		//rotate at tthe supergate
		if((test==true)&&(!vid.battleCommence)&&(!attack.move304camera)){
			Cam.transform.position = target.position;
			_direction = (ship2.transform.position - Cam.transform.position).normalized;
			_look = Quaternion.LookRotation(_direction);
			Cam.transform.rotation = Quaternion.Slerp(Cam.transform.rotation,_look,Time.deltaTime*20);
		}
		//start the vid sequence
		if((Vector3.Distance(ship2.transform.position, dir1[3]) <=12)&&(!vid.battleCommence)&&(!attack.move304camera)){
			playVid1 = true;
			test = false;
		}

		if(vid.battleCommence){
			playVid1=false;
			if(!commence)
				changeCameraAngle = true;
			vid.battleCommence = false;
			commence = true;
		}

		if((counter==4)&&(Cam.transform.position!= target.position)){
			Cam.transform.position = target.position;
			Vector3 po = new Vector3(0,1,0);
			Cam.transform.rotation = Quaternion.AngleAxis(180,po);
			
			changeCameraAngle = true;
		}

		if((commence)&&(counter <=6)){
			moveSpeed = 100;
			_direction = (game.transform.position - Cam.transform.position).normalized;
			_look = Quaternion.LookRotation(_direction);
			Cam.transform.rotation = Quaternion.Slerp(Cam.transform.rotation, _look,Time.deltaTime*moveSpeed);
			Cam.transform.position = Vector3.MoveTowards(Cam.transform.position,target.position, Time.deltaTime*moveSpeed);
			
			if(Cam.transform.position == target.position){
				changeCameraAngle = true;
				longRange = true;
			}
		}

		
		if((counter==7)&&(Cam.transform.position!= target.position)){
			Cam.transform.position = target.position;
			lookVector = GameObject.Find("lookOri");
			Cam.transform.LookAt(lookVector.transform.position);
			changeCameraAngle = true;
		}
		
		if((counter==8)&&(Cam.transform.position!= target.position)){
			moveSpeed = 150;
			Cam.transform.position = Vector3.MoveTowards(Cam.transform.position,target.position, Time.deltaTime*moveSpeed);
			Cam.transform.LookAt(ship2.transform.position);
			if(Cam.transform.position== target.position){
				changeCameraAngle = true;

			}
		}

		if((counter==9)&&(Cam.transform.position!= target.position)){
			Cam.transform.position = target.position;
			lookVector = GameObject.FindGameObjectWithTag("Earth ship2");
			Cam.transform.LookAt(lookVector.transform.position);

			changeCameraAngle = true;
		}

		if((counter==10)&&(Cam.transform.position!= target.position)){
			Cam.transform.position = Vector3.MoveTowards(Cam.transform.position,target.position, Time.deltaTime*moveSpeed);
		}

		if((counter==10)&&(Cam.transform.position== target.position)&&(Cam.transform.rotation != targets)){
			_direction = (lookVector.transform.position - Cam.transform.position).normalized;
			_look = Quaternion.LookRotation(_direction);
			Cam.transform.rotation = Quaternion.Slerp(Cam.transform.rotation, _look,Time.deltaTime*10);
		}


		if((counter ==10)&&(Cam.transform.rotation ==targets)){
			changeCameraAngle = true;
		}
		
		if(counter ==11){
			if(Cam.transform.position != target.position){
				_direction = (ship2.transform.position - Cam.transform.position).normalized;
				_look = Quaternion.LookRotation(_direction);
				Cam.transform.rotation = Quaternion.Slerp(Cam.transform.rotation, _look,Time.deltaTime*moveSpeed);
			}
			Cam.transform.position = target.position;
			
		}
		
		if(reachDestination.reachDestination){
			changeCameraAngle = true;
			reachDestination.reachDestination = false;
		}
		
		if((counter ==12)&&(Cam.transform.position != target.position)){
			Cam.transform.position = target.position;
			Cam.transform.rotation = Quaternion.Euler(Cam.transform.rotation.x-90,Cam.transform.rotation.y-300,Cam.transform.rotation.z+220);
			moveOri = true;
		}

		if(removedShip ==null){
			changeCameraAngle = true;
		}

		if((counter ==13)&&(!port)){
			Cam.transform.position = target.position;
			
			lookVector = GameObject.Find("GauoldSpawn");

			//changeCameraAngle = true;
			port = true;
		}

		if((port)&&(counter>=13)){
			Cam.transform.LookAt(lookVector.transform.position);
			spawn = gameObject.GetComponent<spawnGauold>();
			spawn.bringForth = true;
		//	changeCameraAngle = true;
		}

		if((counter ==14)&&(!cameraOneil)){
			Cam.transform.position = target.position;
			lookVector = GameObject.Find("Asgard_s Oneill");
			Cam.transform.LookAt(lookVector.transform.position);
			cameraOneil = true;
		}

		if((counter ==14)&&(cameraOneil)){
			if(Vector3.Distance(lookVector.transform.position,Cam.transform.position)<=300)
				Cam.transform.LookAt(lookVector.transform.position);
			else
				lookVector =  GameObject.Find("Hatak - 7");

			if(lookVector !=null){
				if(lookVector.name =="Hatak - 7"){
					moveShip7 = true;
				}
				
				if(lookVector.name =="Hatak - 5"){
					moveShip7 = false;
					moveShip5 = true;
				}
			}else{
				lookVector =  GameObject.Find("Hatak - 5");
			}

		}

		if(changeCameraAngle){
			if(counter < CamerasPoints.Length-1){
				counter+=1;
				for(int i =0; i < CamerasPoints.Length; i ++){
					if(CamerasPoints[i].name == "CameraPoint"+counter){
						target = CamerasPoints[i].transform;
						changeCameraAngle = false;
					}
				}
			}
		}else{
			changeCameraAngle = false;
		}
	}
}
