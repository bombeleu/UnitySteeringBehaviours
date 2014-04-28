using UnityEngine;
using System.Collections;

public class Attack304 : MonoBehaviour {
	public GameObject fireRound,fireRound1,fireRound2,fireRound3,fireRound4,fireRound5,fireRoundMissile1,fireRoundMissile2, fire;
	GameObject enemyShip1,enemyShip2,enemyShip3,enemyShip4;
	Transform target;
	
	GameObject mainCamera;
	movement startBattle;
	//collideWithShield collide;
	// Use this for initialization
	void Start () {
		fireRound = GameObject.Find("cannon1");
		fireRound1 = GameObject.Find("cannon2");
		fireRound2 = GameObject.Find("cannon3");
		fireRound3 = GameObject.Find("cannon4");
		fireRound4 = GameObject.Find("cannon5");
		fireRound5 = GameObject.Find("cannon6");

		fireRoundMissile1 = GameObject.Find("missile1");
		fireRoundMissile2 = GameObject.Find("missile2");

		enemyShip1 = GameObject.FindGameObjectWithTag("Ori Mothership - 1");
		enemyShip2 = GameObject.FindGameObjectWithTag("Ori Mothership - 2");
		enemyShip3 = GameObject.FindGameObjectWithTag("Ori Mothership - 3");
		enemyShip4 = GameObject.FindGameObjectWithTag("Ori Mothership - 4");
		
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		startBattle = mainCamera.GetComponent<movement>(); 
	}
	bool up = false;
	// Update is called once per frame
	void Update () {
		Debug.Log(fire.name+ "     "+startBattle.commence);

		if((fire!=null)&&(startBattle.commence)){
			if(!up){
				fire=Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
				fire.tag="Fire";
				up = true;
				//fire.tag = "Fire";
			}
			fire.transform.position = Vector3.MoveTowards(fire.transform.position,
			                                              enemyShip1.transform.position,
			                                              100);
		}
	}
}
