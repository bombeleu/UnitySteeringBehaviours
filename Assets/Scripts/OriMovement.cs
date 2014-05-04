using UnityEngine;
using System.Collections;

public class OriMovement : MonoBehaviour {
	private Transform target;
	private int moveSpeed, rotationSpeed, maxDistance, numberOfPointsInMovementAllowance;
	public Vector3[] path;
	private Transform myTransform;
	public int counter = 0;
	public string tagName;
	public GameObject movementAllowance,ObjPlacement,wayPoint, mainCamera,WormHole;
	public GameObject[] gameChoice;
	movement moving;
	
	OriPath1 pa;
	OriPath2 pa1;
	OriPath3 pa2;
	OriPath4 pa3;
	
	void Awake ()
	{
		if(tagName=="Ori Mothership - 1"){
			pa = new OriPath1();
			path = pa.Route();
		}
		if(tagName=="Ori Mothership - 2"){
			pa1 = new OriPath2();
			path = pa1.Route();
		}
		if(tagName=="Ori Mothership - 3"){
			pa2 = new OriPath3();
			path = pa2.Route();
		}
		if(tagName=="Ori Mothership - 4"){
			pa3 = new OriPath4();
			path = pa3.Route();
		}
		moveSpeed = 300;
		rotationSpeed = 50;
	}

	void Start ()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		moving = mainCamera.GetComponent<movement>();
		movementAllowance = GameObject.FindGameObjectWithTag (tagName);

		myTransform = movementAllowance.transform;	
	
		ObjPlacement = new GameObject();

		gameChoice = new GameObject[path.Length];
		numberOfPointsInMovementAllowance = path.Length;
		for(int i =0; i < path.Length; i ++){
			wayPoint = Instantiate(ObjPlacement,path[i], Quaternion.identity) as GameObject;
			wayPoint.name = "OriMovement" +i;
			gameChoice[i] = wayPoint;
		}
		target = gameChoice [counter].transform;
		WormHole = GameObject.FindGameObjectWithTag("adventerison");
		maxDistance = 4;
	}

	// Update is called once per frame
	void Update ()
	{
		if(moving.moveOri ==true){
			if(counter < numberOfPointsInMovementAllowance-1){
				ParticleEmitter partials;
				partials = WormHole.GetComponent("EllipsoidParticleEmitter").particleEmitter;
				partials.emit = true;
				Quaternion rot;
				rot = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
				myTransform.rotation = rot;
				if (Vector3.Distance (target.position, myTransform.position) >= maxDistance) {
					myTransform.position += new Vector3 (myTransform.forward.x * moveSpeed * Time.deltaTime, 0, myTransform.forward.z * moveSpeed * Time.deltaTime);
				}
				if (Vector3.Distance (target.position, myTransform.position)<= maxDistance) {
					counter ++;
					if(counter< gameChoice.Length)
						target = gameChoice [counter].transform;
					if(counter >=3)
						myTransform.transform.rotation = new Quaternion(0,180,0,0);
				}
			}
			if(moving.counter ==12){
				if(moving.moveOri){
					target = gameChoice [4].transform;
					if (Vector3.Distance (target.position, myTransform.position)<= maxDistance) {
						myTransform.position += new Vector3 (myTransform.forward.x * moveSpeed * Time.deltaTime,0, myTransform.forward.z * moveSpeed * Time.deltaTime);
					}
					else{
						moving.moveOri = false;
					}
				}

			}
		}
	}
}