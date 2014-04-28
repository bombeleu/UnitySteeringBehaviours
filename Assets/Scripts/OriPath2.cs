using UnityEngine;
using System.Collections;

public class OriPath2{
	public Vector3[] PathMovement;
	
	void Start(){
		
	}
	
	public Vector3[] Route(){
		PathMovement = new Vector3[4];

		PathMovement[0] = new Vector3(179.2f, 235.51f, -62.785f);
		PathMovement[1] = new Vector3(179.2f, 235.51f, -682.16f);
		PathMovement[2] = new Vector3(179.694f, 235.51f, -1000.0f);
		PathMovement[3] = new Vector3(179.694f, 235.51f, -1300.0f);
		return PathMovement;
	}
}