using UnityEngine;
using System.Collections;

public class OriPath3 {
	public Vector3[] PathMovement;
	
	void Start(){
		
	}
	
	public Vector3[] Route(){
		PathMovement = new Vector3[5];
		PathMovement[0] = new Vector3(179.2f, 235.571f, -62.785f);
		PathMovement[1] = new Vector3(179.2f, 235.571f, -682.16f);
		PathMovement[2] = new Vector3(-179.694f, 235.571f, -1000.0f);
		PathMovement[3] = new Vector3(-179.694f, 235.571f, -1300.0f);
		PathMovement[4] = new Vector3(-179.694f, 235.571f, -1500.0f);
		
		return PathMovement;
	}
}
