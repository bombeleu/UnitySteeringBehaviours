using UnityEngine;
using System.Collections;

public class moveONeil : MonoBehaviour {

	GameObject move, mainCamera,otherShips;
	public bool reachDestination = false, check = false;
	bool secondaryMovement;
	Vector3 oriMother;
	public string attackName;
	movement moving;
	Vector3 _direction;
	Quaternion _look;
	// Use this for initialization
	void Start () {
		move = GameObject.Find("Ori Mothership - 2");
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		moving = mainCamera.GetComponent<movement>();

	}

	
	// Update is called once per frame
	void Update () {
		if(moving.counter ==12){
			Vector3 moveMe = new Vector3(1738.411f,235,-2844.331f);
			transform.position = Vector3.MoveTowards(transform.position, moveMe,10);
			_direction = (moveMe - transform.position).normalized;
			_look = Quaternion.LookRotation(_direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, _look,Time.deltaTime*10);
		}
		if(moving.counter ==14){
			transform.position = Vector3.MoveTowards(transform.position, move.transform.position,10);
			_direction = (move.transform.position - transform.position).normalized;
			_look = Quaternion.LookRotation(_direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, _look,Time.deltaTime*10);
		}
	}
}
