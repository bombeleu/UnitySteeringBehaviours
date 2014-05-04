using UnityEngine;
using System.Collections;

public class Attack304 : MonoBehaviour {
	public GameObject fireRound,fireRound1,fireRound2,fireRound3,fireRound4,fireRound5,fireRoundMissile1,
	fireRoundMissile2, fire, lazerRound,missile,missileRound,rounds2;
	GameObject enemyShip1,enemyShip2,enemyShip3,enemyShip4;
	Transform target;
	
	GameObject mainCamera;
	movement startBattle;
	bool lazer = false,missileLaunch = false,
	once = false,lazerVolley=false,lazerVolley1=false,
	missileLaunch1 = false;
	public bool move304camera =false;
	float countForMissile = 0, roundsTheSecond=0;
	int counter = 0;
	collideWithShield collide;
	// Use this for initialization
	void Start () {
		enemyShip1 = GameObject.FindGameObjectWithTag("Ori Mothership - 1");
		enemyShip2 = GameObject.FindGameObjectWithTag("Ori Mothership - 2");
		enemyShip3 = GameObject.FindGameObjectWithTag("Ori Mothership - 3");
		enemyShip4 = GameObject.FindGameObjectWithTag("Ori Mothership - 4");

		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		startBattle = mainCamera.GetComponent<movement>();
	}

	// Update is called once per frame
	void Update () {
		if((fire!=null)&&(startBattle.commence)){
			if(!lazer){
				lazerRound=Instantiate(fire,fireRound.transform.position, Quaternion.identity) as GameObject;
				lazerRound.tag="Fire";
				addTarget(lazerRound);
				lazer = true;
			}
			if(countForMissile <=1)
				countForMissile += 0.05f;
			if((countForMissile >=0.9f)&&(!once)){
				missileLaunch = true;
				lazerVolley = true;
				once = true;
			}
			if(missileLaunch){
				missileRound = Instantiate(missile,fireRoundMissile1.transform.position, Quaternion.identity) as GameObject;
				missileLaunch = false;
				addTarget(missileRound);
			}
			if(lazerVolley){
				rounds2= Instantiate(fire,fireRound1.transform.position, Quaternion.identity) as GameObject;
				addTarget(rounds2);
				if(counter<=3){
					if(Vector3.Distance(rounds2.transform.position,fireRound1.transform.position)>=25){
						rounds2= Instantiate(fire,fireRound1.transform.position, Quaternion.identity) as GameObject;
						addTarget(rounds2);
					}
				}

				counter +=1;
				if(counter >=3){
					lazerVolley = false;
					counter=0;
				}
			}
			if(lazerVolley==false){
				lazerVolley1=true;
				missileLaunch1 = true;
			}

			if(rounds2!=null){
				if(Vector3.Distance(rounds2.transform.position,fireRound.transform.position)<=500){
					move304camera = true;
				}
			}
		}
	}

	void addTarget(GameObject addition){
		collide = addition.GetComponent<collideWithShield>();
		collide.attackName = "Ori Mothership - 1";
	}
}
