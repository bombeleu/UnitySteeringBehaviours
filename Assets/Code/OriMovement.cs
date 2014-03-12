using UnityEngine;
using System.Collections;

public class OriMovement : MonoBehaviour {
	
	private Transform target;
	private int moveSpeed, rotationSpeed, maxDistance, numberOfPointsInMovementAllowance;
	public Vector3[] path;
	private Transform myTransform;
	public int counter = 0;
	public string tagName;
	public GameObject movementAllowance,ObjPlacement;
	
	
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

	public GameObject[] gameChoice;
	GameObject ga;

	void Start ()
	{
		movementAllowance = GameObject.FindGameObjectWithTag (tagName);

		myTransform = movementAllowance.transform;	
	
		ObjPlacement = new GameObject();

		gameChoice = new GameObject[path.Length];
		numberOfPointsInMovementAllowance = path.Length;
		for(int i =0; i < path.Length; i ++){
			ga = Instantiate(ObjPlacement,path[i], Quaternion.identity) as GameObject;
			ga.name = "OriMovement" +i;
			gameChoice[i] = ga;
		}
		target = gameChoice [counter].transform;
		
		maxDistance = 4;
	}
	
	int changeWalkingDirection = 0;
	// Update is called once per frame
	void Update ()
	{
		if(counter < numberOfPointsInMovementAllowance){
			Quaternion rot;
			rot = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			myTransform.rotation = rot;

			Vector3 tar = new Vector3 (target.position.x, myTransform.position.y, target.position.z);
			if (Vector3.Distance (target.position, myTransform.position) >= maxDistance) {
				//more towards target
				myTransform.position += new Vector3 (myTransform.forward.x * moveSpeed * Time.deltaTime, 0, myTransform.forward.z * moveSpeed * Time.deltaTime);
				
			}
			if (Vector3.Distance (target.position, myTransform.position)<= maxDistance) {
				counter ++;

				target = gameChoice [counter].transform;
			}
		}
	}	
}
